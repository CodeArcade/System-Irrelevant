using Bliss.Component.Sprites.Office;
using Bliss.Component.Sprites.Office.Documents;
using Bliss.Factories;
using Bliss.Models;
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
        private List<string> DocumentsToSpawn { get; set; } = new List<string>();

        protected override void OnLoad(params object[] parameter)
        {
            if (PlayerStats is null)
            {
                PlayerStats = new PlayerStats();
            }
        }

        public override void Update(GameTime gameTime)
        {
            PreviousMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();

            if (PlayerStats.Day == 0) Intro();
            if (PlayerStats.Day > 0)
            {
                HandleDocumentSpawn(gameTime);
            }

            // TODO: End day at 5 pm
            // TODO: Start first day call at first day instantly -> once finished start clock

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) SpawnDocument();

            if (CurrentMouse.RightButton == ButtonState.Released && PreviousMouse.RightButton == ButtonState.Pressed && CurrentDetailViewComponents.Any())
            {
                RemoveDetailView();
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

            if (DocumentSpawnTimer >= 1)
            {
                if (DocumentsToSpawn.Any())
                {
                    DocumentsToSpawn.RemoveAt(0);
                    SpawnDocument();
                    DocumentSpawnTimer = 0;
                }

                if (DocumentCount <= 1) if (!DocumentsToSpawn.Contains("minimum documents")) DocumentsToSpawn.Add("minimum documents");
                if (Clock.Minute % 10 == 0) if (!DocumentsToSpawn.Contains(Clock.Minute.ToString())) DocumentsToSpawn.Add(Clock.Minute.ToString());
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
            RemoveDetailView();

            DocumentOrganizer organizer = (DocumentOrganizer)sender;
            if (!organizer.Validate(CurrentDocument)) PlayerStats.WronglySortedDocuments++;

            CurrentDocument.IsRemoved = true;
        }

        private void ImportantPhoneCallFinished(object sender, EventArgs e)
        {
            var validators = ((PhoneCall)sender).NewValidators;
            foreach (var validatorGroup in validators)
            {
                DocumentOrganizer organizer = DocumentOrganizers.First(x => x.Id == validatorGroup.Key);
                organizer.Validators.AddRange(validatorGroup.Value);
            }
        }

        private void DocumentClicked(object sender, EventArgs e)
        {
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

            AudioManager.PlayEffect(ContentManager.DocumentPutDownSoundEffect);
        }

        private void ToggleClickableOfDocuments(bool clickable)
        {
            Bin.CanBeClicked = !clickable;

            foreach (Component.Component component in Layers[(int)States.Layers.PlayingArea])
            {
                if (component is BaseDocument document)
                    document.CanBeClicked = clickable;

                if (component is DocumentOrganizer organizer)
                    organizer.CanBeClicked = !clickable;
            }
        }
    }
}