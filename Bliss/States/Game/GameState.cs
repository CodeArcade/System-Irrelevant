using Bliss.Component.Sprites.Office;
using Bliss.Component.Sprites.Office.Documents;
using Bliss.Factories;
using Bliss.Models;
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

        protected override void OnLoad(params object[] parameter)
        {
            if (PlayerStats is null)
            {
                PlayerStats = new PlayerStats();
            }

            if (parameter.Any())
            {
                PlayerStats = (PlayerStats)parameter[0];
                PlayerStats.DocumentsLeft = 0;
                PlayerStats.MissedCalls = 0;
                PlayerStats.WronglyEndedCalls = 0;
                PlayerStats.WronglySortedDocuments = 0;
            }
        }

        public override void Update(GameTime gameTime)
        {
            PreviousMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();

            if (PlayerStats.Day == 0) Intro();

            if (Clock.Hour == 17)
            {
                PlayerStats.DocumentsLeft = DocumentCount;
                StateManager.ChangeTo<SummaryState>(SummaryState.Name, PlayerStats);
                base.Update(gameTime);
                return;
            }

            if (PlayerStats.Day > 0) HandleDocumentSpawn(gameTime);

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
            if (!Phone.IsRinging && !Phone.IsTalking)
            {
                Phone.Ring(PhoneCallFactory.GetIntro());
                Phone.SecondsBeforeMissedCall = int.MaxValue;
            }

            if (Phone.IsTalking) Phone.CanBeClicked = false;

            if (!Phone.IsCallOver) return;
            Phone.CanBeClicked = true;

            if (!Phone.IsTalking) return;
            PlayerStats.Day = 1;
            Clock.Reset();
            Clock.Enabled = true;
        }

        private void HandleDocumentSpawn(GameTime gameTime)
        {
            DocumentSpawnTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (DocumentSpawnTimer >= SecondsToNextDocument)
            {
                SpawnDocument();
                SecondsToNextDocument = new Random().Next(5, 16);
                DocumentSpawnTimer = 0;
            }
        }

        private void SpawnDocument()
        {
            AudioManager.PlayEffect(ContentManager.DocumentSpawnedSoundEffect);
            Random random = new Random();
            BaseDocument document = DocumentFactory.GetRandomDocument(DocumentSpawnPoints[random.Next(0, DocumentSpawnPoints.Count)].Position, Table.Rectangle);
            document.OnClick += DocumentClicked;
            AddComponent(document, States.Layers.PlayingArea);
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