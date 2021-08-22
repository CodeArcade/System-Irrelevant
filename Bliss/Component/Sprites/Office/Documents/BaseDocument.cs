using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Bliss.Component.Sprites.Office.Documents
{
    public abstract class BaseDocument : Sprite
    {
        private MouseState CurrentMouse { get; set; }
        private MouseState PreviousMouse { get; set; }
        private bool IsMouseOver { get; set; }
        public bool CanBeClicked { get; set; } = true;
        public event EventHandler OnClick;

        private Vector2 SpawnPoint { get; set; }
        private float DistanceToTravel { get; set; }
        public bool DidLand { get; set; }

        public uint Id { get; set; }
        private static uint LatestId { get; set; }
        private static List<BaseDocument> DocumentsUnderMouse { get; set; } = new List<BaseDocument>();

        public BaseDocument(Vector2 spawnPoint, Rectangle tableArea)
        {
        }

        protected void Load(Vector2 spawnPoint, Rectangle tableArea)
        {
            Random random = new Random();

            SpawnPoint = spawnPoint;
            Position = spawnPoint;

            // pick random position on table - reduce current size so document fits fully 
            Vector2 targetDestination = new Vector2(
                random.Next(tableArea.X + Size.Width, tableArea.Width - Size.Width),
                random.Next(tableArea.Y, tableArea.Height - Size.Height)
                );

            Speed = 3000;
            DistanceToTravel = DistanceTo(targetDestination);
            Direction = DirectionTo(targetDestination);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Color = Color.White;
            if (IsMouseOver && IsTopMostDocumentUnderMouse() && CanBeClicked) Color = Color.Yellow;

            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateMouseOver();

            // We are moving only a distance instead to the point, cause of the speed the exact point may be missed
            if (DistanceToTravel < DistanceTo(SpawnPoint))
            {
                if (!DidLand)
                {
                    AudioManager.PlayEffect(ContentManager.DocumentLandedSoundEffect);
                    Id = ++LatestId; // I hate me for that
                }

                DidLand = true;
                return;
            }

            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        private void UpdateMouseOver()
        {
            PreviousMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();

            Rectangle mouseRectangle = new Rectangle(CurrentMouse.X, CurrentMouse.Y, 1, 1);
            Rectangle previousMouseRectangle = new Rectangle(CurrentMouse.X, CurrentMouse.Y, 1, 1);

            IsMouseOver = false;
            if (DocumentsUnderMouse.Contains(this)) DocumentsUnderMouse.Remove(this);

            if (mouseRectangle.Intersects(Rectangle))
            {
                DocumentsUnderMouse.Add(this);
                IsMouseOver = true;

                if (IsTopMostDocumentUnderMouse() && CanBeClicked && CurrentMouse.LeftButton == ButtonState.Released && PreviousMouse.LeftButton == ButtonState.Pressed)
                    OnClick?.Invoke(this, new EventArgs());
            }
        }

        private bool IsTopMostDocumentUnderMouse() => Id == DocumentsUnderMouse.Max(x => x.Id);

        /// <summary>
        /// This functions returns the components for the detail view of the document
        /// </summary>
        public abstract List<Component> GetDetailViewComponents();
    }
}
