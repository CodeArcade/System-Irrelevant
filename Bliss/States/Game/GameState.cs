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
                if (parameter[0] is PlayerStats)
                {
                    PlayerStats = (PlayerStats)parameter[0];
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

            Calls.Add(PhoneCallFactory.GetRandomImportant());
            SecondsToNextPhoneCall = new Random().Next(25, 45);
        }

        public override void Update(GameTime gameTime)
        {
            PreviousMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();

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
                    PlayerStats.DocumentsLeft = DocumentCount;
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

            if (CurrentMouse.RightButton == ButtonState.Released && PreviousMouse.RightButton == ButtonState.Pressed && CurrentDetailViewComponents.Any())
            {
                if (!(CurrentDocument is null))
                {
                    RemoveDetailView();
                }
            }

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
            StateManager.ChangeTo<MenuState>(MenuState.Name);
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
            AddComponent(document, States.Layers.PlayingArea);
        }

        private void HandlePhoneCall(GameTime gameTime)
        {
            if (!Calls.Any() || Phone.IsInUse) return;

            PhoneCallTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (PhoneCallTimer >= SecondsToNextPhoneCall)
            {
                int callToPlay = Random.Next(0, Calls.Count);
                Phone.Ring(Calls[callToPlay]);
                Calls.RemoveAt(callToPlay);

                SecondsToNextPhoneCall = Random.Next(30, Math.Max(Clock.RemainingSeconds / (Calls.Count + 1), 32));
                PhoneCallTimer = 0;
            }
        }

        private void DocumentOrganizerClicked(object sender, EventArgs e)
        {
            DocumentOrganizer organizer = (DocumentOrganizer)sender;
            if (!organizer.Validate(CurrentDocument)) PlayerStats.WronglySortedDocuments++;

            CurrentDocument.IsRemoved = true;

            RemoveDetailView();
        }

        private void ImportantPhoneCallFinished(object sender, EventArgs e)
        {
            var validators = ((PhoneCall)sender).NewValidators;
            foreach (var validatorGroup in validators)
            {
                DocumentOrganizer organizer = DocumentOrganizers.First(x => x.Id == validatorGroup.Key);
                organizer.Validators = validatorGroup.Value;
            }
        }

        private void DocumentClicked(object sender, EventArgs e)
        {
            if (!(CurrentDocument is null)) return;

            ToggleClickableOfDocuments(false);

            foreach (Component.Component component in CurrentDetailViewComponents)
                component.IsRemoved = true;

            BaseDocument document = (BaseDocument)sender;
            CurrentDetailViewComponents = document.GetDetailViewComponents();

            foreach (Component.Component component in CurrentDetailViewComponents)
                AddComponent(component, States.Layers.DocumentDetailView);

            CurrentDocument = document;

            AudioManager.PlayEffect(ContentManager.DocumentPickedUpSoundEffect);
        }

        private void RemoveDetailView()
        {
            foreach (Component.Component component in CurrentDetailViewComponents)
                component.IsRemoved = true;

            ToggleClickableOfDocuments(true);

            CurrentDocument = null;

            AudioManager.PlayEffect(ContentManager.DocumentPutDownSoundEffect);
        }

        private void ToggleClickableOfDocuments(bool clickable)
        {
            Bin.CanBeClicked = !clickable;

            foreach (Component.Component component in Layers[(int)States.Layers.PlayingArea])
            {
                if (component is BaseDocument document)
                {
                    document.CanBeClicked = clickable;
                    document.CanBeDragged = clickable;
                }

                if (component is DocumentOrganizer organizer)
                    organizer.CanBeClicked = !clickable;
            }
        }
    }
}