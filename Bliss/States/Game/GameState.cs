using Bliss.Component.Sprites.Office;
using Bliss.Component.Sprites.Office.Documents;
using Bliss.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bliss.States.Game
{
    public partial class GameState : State
    {
        public static string Name = "Game";

        private MouseState CurrentMouse { get; set; }
        private MouseState PreviousMouse { get; set; }

        private List<Component.Component> CurrentDetailViewComponents { get; set; } = new List<Component.Component>();
        private BaseDocument CurrentDocument { get; set; }

        private PlayerStats PlayerStats { get; set; }

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

            // TODO: End day at 5 pm
            // TODO: Start first day call at first day instantly -> once finished start clock

            if (Keyboard.GetState().IsKeyDown(Keys.Space)) SpawnDocument();
            if (Keyboard.GetState().IsKeyDown(Keys.T)) Phone.Ring(); // TODO: Ring at random points of time during day (2-3 times), once of which tells you important stuff
            if (Keyboard.GetState().IsKeyDown(Keys.C)) // TODO: start at new days
            {
                Clock.Enabled = !Clock.Enabled;
                Clock.Reset();
            }

            if (CurrentMouse.RightButton == ButtonState.Released && PreviousMouse.RightButton == ButtonState.Pressed && CurrentDetailViewComponents.Any())
            {
                RemoveDetailView();
            }

            base.Update(gameTime);
        }

        private void SpawnDocument()
        {
            // TODO: Spawn based on time

            AudioManager.PlayEffect(ContentManager.DocumentSpawnedSoundEffect);
            Random random = new Random();
            Invoice invoice = new Invoice(DocumentSpawnPoints[random.Next(0, DocumentSpawnPoints.Count)].Position, Table.Rectangle)
            {
                Size = SizeManager.GetSize(150, 200)
            };
            invoice.OnClick += DocumentClicked;
            AddComponent(invoice, States.Layers.PlayingArea);
        }

        private void DocumentOrganizerClicked(object sender, EventArgs e)
        {
            RemoveDetailView();
            CurrentDocument.IsRemoved = true;
            PlayerStats.SortedDocuments++;
            // TODO: Prüfen ob richtig eingeordnet
        }

        private void BinClicked(object sender, EventArgs e)
        {
            RemoveDetailView();
            CurrentDocument.IsRemoved = true;
            PlayerStats.ThrahsedDocuments++;
            // TODO: Prüfen ob richtig eingeordnet
        }

        private void AcceptedCall(object sender, EventArgs e)
        {
            PlayerStats.PickedUpCalls++;
            // TODO: Play call audio and show sub titles
        }

        private void EndCall(object sender, EventArgs e)
        {
            // TODO: Check if call was important and not over
            PlayerStats.WronglyEndedCalls++; 
        }

        private void MissedCall(object sender, EventArgs e)
        {
            PlayerStats.MissedCalls++;
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