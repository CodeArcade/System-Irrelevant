using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bliss.Component.Sprites.Office.Documents
{
    public abstract class BaseDocument : Clickable
    {
        private Vector2 SpawnPoint { get; set; }
        private float DistanceToTravel { get; set; }
        public bool DidLand { get; set; }

        public bool CanBeDragged { get; set; } = true;

        public bool IsHeld { get; private set; } = false;
        private Vector2 HoldOffset { get; set; }

        public event EventHandler OnDragStopped;
        public event EventHandler OnDragUpdate;

        public int Id { get; set; }
        private static int LatestId { get; set; }
        private static List<BaseDocument> DocumentsUnderMouse { get; set; } = new List<BaseDocument>();

        public double TimeSinceHeld { get; set; }

#pragma warning disable IDE0060 // Remove unused parameter
        public BaseDocument(Vector2 spawnPoint, Rectangle tableArea)
#pragma warning restore IDE0060 // Remove unused parameter
        {
        }

        protected void Load(Vector2 spawnPoint, Rectangle tableArea)
        {
            Random random = new Random();

            SpawnPoint = spawnPoint;
            Position = spawnPoint;
            HoverColor = Color.Yellow;

            // pick random position on table - reduce current size so document fits fully 
            Vector2 targetDestination = new Vector2(
                random.Next(tableArea.X + (int)(Size.Width * 1.5), tableArea.Width - (Size.Width * 2)),
                random.Next(tableArea.Y, tableArea.Height - Size.Height)
                );

            Speed = 3000;
            DistanceToTravel = DistanceTo(targetDestination);
            Direction = DirectionTo(targetDestination);
            CanBeClicked = false;
            CanBeDragged = false;
        }

        public override void Update(GameTime gameTime)
        {
            TimeSinceHeld += gameTime.ElapsedGameTime.TotalSeconds;
            if (TimeSinceHeld >= 1000) TimeSinceHeld = 0;

            // We are moving only a distance instead to the point, cause of the speed the exact point may be missed
            if (DistanceToTravel < DistanceTo(SpawnPoint) && !DidLand)
            {
                if (!DidLand)
                {
                    AudioManager.PlayEffect(ContentManager.DocumentLandedSoundEffect);
                    Id = ++LatestId; // I hate myself for that
                }

                DidLand = true;
                CanBeClicked = true;
                CanBeDragged = true;
                return;
            }

            if (DidLand)
            {
                CanBeClicked = true;
                SortDocumentsById();
                UpdateMouse();
                UpdateDrag();
                UpdateMouseOverClick();
            }
            else
            {
                Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            base.Update(gameTime);
        }

        private void UpdateMouse()
        {
            PreviousMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();
        }

        protected override void UpdateHoverColor()
        {
            if (IsHeld) return;

            Color = Color.White;
            if (IsMouseOver && CanBeClicked && CanBeDragged && IsTopMostDocumentUnderMouse())
            {
                Color = HoverColor;
            }
        }

        protected override void UpdateMouseOverClick()
        {
            IsMouseOver = false;
            if (DocumentsUnderMouse.Contains(this)) DocumentsUnderMouse.Remove(this);

            if (IsMouseOverDocument())
            {
                DocumentsUnderMouse.Add(this);
                IsMouseOver = true;

                if (IsTopMostDocumentUnderMouse() &&
                    CanBeClicked &&
                    CurrentMouse.LeftButton == ButtonState.Released &&
                    PreviousMouse.LeftButton == ButtonState.Pressed)
                    Click();
            }
        }

        private void UpdateDrag()
        {
            if (!CanBeDragged) return;
            if (!IsTopMostDocumentUnderMouse()) return;

            if (IsHeld)
            {
                OnDragUpdate?.Invoke(this, new EventArgs());
                CanBeClicked = false;
                Position = new Vector2(CurrentMouse.X - HoldOffset.X, CurrentMouse.Y - HoldOffset.Y);
                Id = int.MaxValue;
                TimeSinceHeld = 0;
            }

            if (CurrentMouse.LeftButton == ButtonState.Released)
            {
                IsHeld = false;
                OnDragStopped?.Invoke(this, new EventArgs());
            }

            if (CurrentMouse.LeftButton == ButtonState.Pressed &&
                PreviousMouse.LeftButton == ButtonState.Pressed &&
                !IsHeld)
            {
                Rectangle rect = new Rectangle(PreviousMouse.X - 2, PreviousMouse.Y - 2, 4, 4);
                if (!rect.Contains(CurrentMouse.X, CurrentMouse.Y))
                {
                    IsHeld = true;
                    CanBeClicked = false;
                    HoldOffset = new Vector2(CurrentMouse.X - Position.X, CurrentMouse.Y - Position.Y);
                }
            }
        }

        private bool IsMouseOverDocument()
        {
            Rectangle mouseRectangle = new Rectangle(CurrentMouse.X, CurrentMouse.Y, 1, 1);
            return mouseRectangle.Intersects(Rectangle);
        }

        private bool IsTopMostDocumentUnderMouse()
        {
            if (!DocumentsUnderMouse.Any()) return false;

            return Id == DocumentsUnderMouse.Max(x => x.Id);
        }

        private void SortDocumentsById()
        {
            DocumentsUnderMouse = DocumentsUnderMouse.OrderBy(x => x.Id).ToList();
            if (Id == int.MaxValue)
            {
                Id = ++LatestId;
            }
        }

        public override void OnRemove()
        {
            Id = int.MinValue;
            base.OnRemove();
        }

        /// <summary>
        /// This functions returns the components for the detail view of the document
        /// </summary>
        public abstract List<Component> GetDetailViewComponents();
    }
}
