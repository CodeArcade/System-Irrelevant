using Bliss.Component.Sprites.Office;
using Bliss.Component.Sprites.Office.Documents;
using Bliss.Factories;
using Bliss.Models;
using Bliss.States.GameOver;
using Bliss.States.Summary;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace Bliss.States.Game
{
    public partial class GameState : State
    {
        public static string Name = "Game";

        [Dependency]
        public PhoneCallFactory PhoneCallFactory { get; set; }
        [Dependency]
        public DocumentFactory DocumentFactory { get; set; }

        private MouseState CurrentMouse { get; set; }
        private MouseState PreviousMouse { get; set; }

        private KeyboardState CurrentKeyboad { get; set; }
        private KeyboardState PreviousKeyboard { get; set; }

        private List<Component.Component> CurrentDetailViewComponents { get; set; } = new List<Component.Component>();
        private BaseDocument CurrentDocument { get; set; }

        private PlayerStats PlayerStats { get; set; }

        private int DocumentCount => Layers.SelectMany(x => x).Count(x => x is BaseDocument);

        private double DocumentSpawnTimer { get; set; }
        private int SecondsToNextDocument { get; set; }

        private double PhoneCallTimer { get; set; }
        private int SecondsToNextPhoneCall { get; set; }
        private List<PhoneCall> Calls { get; set; }

        private bool PlayTutorial { get; set; }

        private Random Random { get; set; } = new Random();

        protected override void OnLoad(params object[] parameter)
        {
            if (PlayerStats is null)
            {
                PlayerStats = new PlayerStats();
            }

            if (parameter.Any())
            {
                if (parameter[0] is PlayerStats stats)
                {
                    PlayerStats = stats;
                    PlayerStats.DocumentsLeft = 0;
                    PlayerStats.MissedCalls = 0;
                    PlayerStats.WronglyEndedCalls = 0;
                    PlayerStats.WronglySortedDocuments = 0;
                }
                else
                {
                    PlayTutorial = (bool)parameter[0];
                }
            }

            Calls = new List<PhoneCall>();
            int callCount = Random.Next(1, 4);
            for (int i = 0; i < callCount - 1; i++)
                Calls.Add(PhoneCallFactory.GetRandom());

            Calls.Add(PhoneCallFactory.GetImportant());
            SecondsToNextPhoneCall = new Random().Next(25, 45);

            AudioManager.ChangeSong(ContentManager.CalmSong, true);
        }

        public override void Update(GameTime gameTime)
        {
            PreviousMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();

            PreviousKeyboard = CurrentKeyboad;
            CurrentKeyboad = Keyboard.GetState();

            if (PlayerStats.Day == 0) Intro();

            if (Clock.Hour >= 17)
            {
                if (PlayerStats.Warnings >= 3)
                {
                    Outro();
                    base.Update(gameTime);
                    return;
                }

                if (!Phone.IsInUse)
                {
                    PlayerStats.Day++;
                    PlayerStats.DocumentsLeft = DocumentCount;
                    AudioManager.StopMusic();
                    StateManager.ChangeTo<SummaryState>(SummaryState.Name, PlayerStats);
                    base.Update(gameTime);
                    return;
                }
            }

            if (PlayerStats.Day > 0)
            {
                HandleDocumentSpawn(gameTime);
                HandlePhoneCall(gameTime);

                if (!Clock.Enabled)
                {
                    Clock.Reset();
                    Clock.Enabled = true;
                }
            }

            if (
                (
                 (CurrentMouse.RightButton == ButtonState.Released && PreviousMouse.RightButton == ButtonState.Pressed) ||
                 (CurrentKeyboad.IsKeyUp(Keys.Escape) && PreviousKeyboard.IsKeyDown(Keys.Escape)) ||
                 (CurrentKeyboad.IsKeyUp(Keys.Space) && PreviousKeyboard.IsKeyDown(Keys.Space))
                 ) && CurrentDetailViewComponents.Any())
                RemoveDetailView();

            base.Update(gameTime);
        }

        private void Intro()
        {
            if (!PlayTutorial)
            {
                PlayerStats.Day = 1;
                return;
            }

            if (!Phone.IsRinging && !Phone.IsTalking && !Phone.IsCallOver)
            {
                Phone.Ring(PhoneCallFactory.GetIntro());
                Phone.SecondsBeforeMissedCall = int.MaxValue;
            }

            if (Phone.IsTalking) Phone.CanBeClicked = false;

            if (!Phone.IsCallOver) return;
            Phone.CanBeClicked = true;

            if (Phone.IsInUse) return;
            PlayerStats.Day = 1;
        }

        private void Outro()
        {
            if (!Phone.IsRinging && !Phone.IsTalking && !Phone.IsCallOver)
            {
                Phone.Ring(PhoneCallFactory.GetOutro());
                Phone.SecondsBeforeMissedCall = int.MaxValue;
            }

            if (Phone.IsTalking) Phone.CanBeClicked = false;

            if (!Phone.IsCallOver) return;
            Phone.CanBeClicked = true;

            if (Phone.IsInUse) return;

            AudioManager.StopMusic();
            StateManager.ChangeTo<GameOverState>(GameOverState.Name);
        }

        private void HandleDocumentSpawn(GameTime gameTime)
        {
            DocumentSpawnTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (DocumentSpawnTimer >= SecondsToNextDocument)
            {
                SpawnDocument();
                SecondsToNextDocument = Random.Next(5, 16);
                DocumentSpawnTimer = 0;
            }
        }

        private void SpawnDocument()
        {
            AudioManager.PlayEffect(ContentManager.DocumentSpawnedSoundEffect);
            BaseDocument document = DocumentFactory.GetRandomDocument(DocumentSpawnPoints[Random.Next(0, DocumentSpawnPoints.Count)].Position, Table.Rectangle);
            document.OnClick += DocumentClicked;
            document.OnDragStopped += DocumentDragStopped;
            document.OnDragUpdate += (sender, e) =>
            {
                if (!Table.Rectangle.Contains(Mouse.GetState().Position))
                {
                    document.Color = Color.OrangeRed;
                }
                else
                {
                    document.Color = Color.White;
                }
            };
            AddComponent(document, States.Layers.PlayingArea);
        }

        private void HandlePhoneCall(GameTime gameTime)
        {
            PhoneCallTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (!Calls.Any() || Phone.IsInUse) return;

            if (PhoneCallTimer >= SecondsToNextPhoneCall)
            {
                Phone.Ring(Calls[0]);
                Calls.RemoveAt(0);

                SecondsToNextPhoneCall = Random.Next(30, Math.Max(Clock.RemainingSeconds / (Calls.Count + 1), 32));
                PhoneCallTimer = 0;
            }
        }

        private void ImportantPhoneCallFinished(object sender, EventArgs e)
        {
            var validators = ((PhoneCall)sender).NewValidators;
            foreach (var validatorGroup in validators)
            {
                DocumentOrganizer organizer = DocumentOrganizers.First(x => x.Id == validatorGroup.Key);
                organizer.Validators = validatorGroup.Value;
            }

            AudioManager.PlayEffect(ContentManager.NewRuleSoundEffect);
            SetStickyNoteValidators();
            StickyNote.Extend(true);
        }

        private void SetStickyNoteValidators()
        {
            StickyNote.ActiveRules = new Dictionary<OrganizerIds, List<Rule>>();

            foreach (DocumentOrganizer organizer in DocumentOrganizers)
                StickyNote.ActiveRules.Add(organizer.Id, organizer.Validators);
        }

        private void DocumentClicked(object sender, EventArgs e)
        {
            if (!(CurrentDocument is null)) return;
            if (CurrentDetailViewComponents.Any()) return;

            ToggleClickableOfDocuments(false);
            StickyNote.CanBeClicked = false;
            StickyNote.CanHover = false;

            foreach (Component.Component component in CurrentDetailViewComponents)
                component.IsRemoved = true;

            BaseDocument document = (BaseDocument)sender;
            CurrentDetailViewComponents = document.GetDetailViewComponents();

            foreach (Component.Component component in CurrentDetailViewComponents)
                AddComponent(component, States.Layers.DocumentDetailView);

            CurrentDocument = document;

            AudioManager.PlayEffect(ContentManager.DocumentPickedUpSoundEffect);
        }

        private void DocumentDragStopped(object sender, EventArgs e)
        {
            if (sender is BaseDocument document)
            {
                if (!Table.Rectangle.Contains(Mouse.GetState().Position))
                {
                    if (!Bin.Validate(document)) PlayerStats.WronglySortedDocuments++;

                    AudioManager.PlayEffect(ContentManager.DocumentThrasedSoundEffect);
                    document.IsRemoved = true;
                }
            }
        }

        private void RemoveDetailView()
        {
            if (!CurrentDetailViewComponents.Any()) return;

            foreach (Component.Component component in CurrentDetailViewComponents)
                component.IsRemoved = true;

            CurrentDetailViewComponents.Clear();

            ToggleClickableOfDocuments(true);
            StickyNote.CanBeClicked = true;
            StickyNote.CanHover = true;

            CurrentDocument = null;

            AudioManager.PlayEffect(ContentManager.DocumentPutDownSoundEffect);
        }

        private void ToggleClickableOfDocuments(bool clickable)
        {
            foreach (Component.Component component in Layers[(int)States.Layers.PlayingArea])
            {
                if (component is BaseDocument document)
                {
                    document.CanBeClicked = clickable;
                    document.CanBeDragged = clickable;
                }

                if (component is DocumentOrganizer organizer)
                {
                    organizer.CanHover = clickable;
                }
            }
        }

        private void StickyNoteClicked(object sender, EventArgs e)
        {
            ToggleClickableOfDocuments(false);

            foreach (Component.Component component in CurrentDetailViewComponents)
                component.IsRemoved = true;

            StickyNote note = (StickyNote)sender;
            CurrentDetailViewComponents = note.GetDetailViewComponents();

            foreach (Component.Component component in CurrentDetailViewComponents)
                AddComponent(component, States.Layers.DocumentDetailView);

            AudioManager.PlayEffect(ContentManager.DocumentPickedUpSoundEffect);
        }
    }
}