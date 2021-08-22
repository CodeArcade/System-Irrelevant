using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bliss.Component.Sprites.Office
{
    public class Clock : Sprite
    {
        public SpriteFont Font { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public bool Enabled { get; set; }

        private double Timer { get; set; }
        public int SecondsBetweenMinutes { get; set; } = 1;

        public Clock()
        {
            Texture = ContentManager.ClockTexture;
            Font = ContentManager.ArialSpriteFont;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            // TODO: Change clock display to Images (0-59)

            if (Enabled)
                spriteBatch.DrawString(Font, $"{Hour.ToString().PadLeft(2, '0')}:{Minute.ToString().PadLeft(2, '0')}", new Vector2(Position.X, Position.Y), Color.Red, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
        }

        public override void Update(GameTime gameTime)
        {
            if (!Enabled) return;

            Timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (Timer >= SecondsBetweenMinutes)
            {
                Minute++;
                if (Minute > 59)
                {
                    Minute = 0;
                    Hour++;
                }

                Timer = 0;
            }

            base.Update(gameTime);
        }

        public void Reset()
        {
            Hour = 8;
            Minute = 0;
        }
    }
}
