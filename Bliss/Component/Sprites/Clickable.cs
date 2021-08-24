using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Bliss.Component.Sprites
{
    public class Clickable : Sprite
    {
        protected MouseState CurrentMouse { get; set; }
        protected MouseState PreviousMouse { get; set; }
        protected bool IsMouseOver { get; set; }
        public bool CanBeClicked { get; set; } = true;
        public event EventHandler OnClick;
        public Color HoverColor { get; set; } = Color.Yellow;

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            UpdateHoverColor();

            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            UpdateMouseOverClick();

            base.Update(gameTime);
        }

        protected virtual void UpdateHoverColor()
        {
            Color = Color.White;
            if (IsMouseOver && CanBeClicked) Color = HoverColor;
        }

        protected virtual void UpdateMouseOverClick()
        {
            PreviousMouse = CurrentMouse;
            CurrentMouse = Mouse.GetState();

            Rectangle mouseRectangle = new Rectangle(CurrentMouse.X, CurrentMouse.Y, 1, 1);

            IsMouseOver = false;
            if (mouseRectangle.Intersects(Rectangle))
            {
                IsMouseOver = true;

                if (CanBeClicked && CurrentMouse.LeftButton == ButtonState.Released && PreviousMouse.LeftButton == ButtonState.Pressed)
                    Click();
            }
        }

        protected virtual void Click()
        {
            OnClick?.Invoke(this, new EventArgs());
        }

        protected bool IsMouseInsideWindow()
        {
            MouseState ms = Mouse.GetState();
            Point pos = new Point(ms.X, ms.Y);
            // somethings wrong... only works on the left side of the screen
            // maybe i'm stupid, but who knows
            return pos.X >= 0 && pos.Y >= 0 && pos.X <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width && pos.Y <= GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
        }
    }
}
