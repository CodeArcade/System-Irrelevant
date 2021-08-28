using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Bliss.Component.Sprites.Office
{
    public class Clock : Sprite
    {
        public int Hour { get; set; }
        public int Minute { get; set; }
        public bool Enabled { get; set; }

        private double Timer { get; set; }
        public float SecondsBetweenMinutes { get; set; } = 0.25f;

        public int TotalTimeInSeconds => (int)((17 - 9) * 60 * SecondsBetweenMinutes);
        public int RemainingSeconds => (int)((17 - Hour) * (60 - Minute) * SecondsBetweenMinutes);

        private List<Texture2D> Numbers { get; set; }

        public Clock()
        {
            Texture = ContentManager.ClockTexture;
            Numbers = new List<Texture2D>()
                {
                    ContentManager.ClockZeroTexture,
                    ContentManager.ClockOneTexture,
                    ContentManager.ClockTwoTexture,
                    ContentManager.ClockThreeTexture,
                    ContentManager.ClockFourTexture,
                    ContentManager.ClockFiveTexture,
                    ContentManager.ClockSixTexture,
                    ContentManager.ClockSevenTexture,
                    ContentManager.ClockEightTexture,
                    ContentManager.ClockNineTexture,
                    ContentManager.ClockColonTexture,
                };
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);

            if (Enabled)
            {
                Rectangle firstDigitRectangle = new Rectangle(Rectangle.X + (int)SizeManager.ScaleForWidth(10), Rectangle.Y + (int)SizeManager.ScaleForHeight(25), Rectangle.Width / 5, (int)(Rectangle.Height * 0.6f));
                spriteBatch.Draw(Numbers[Hour < 10 ? 0 : int.Parse(Hour.ToString().Substring(0, 1))], firstDigitRectangle, Color);

                Rectangle secondDigitRectangle = new Rectangle(Rectangle.X + (Rectangle.Width / 5) + (int)SizeManager.ScaleForWidth(10), Rectangle.Y + (int)SizeManager.ScaleForHeight(21), Rectangle.Width / 5, (int)(Rectangle.Height * 0.6f));
                spriteBatch.Draw(Numbers[Hour < 10 ? Hour : int.Parse(Hour.ToString().Substring(1, 1))], secondDigitRectangle, Color);

                Rectangle thirdDigitRectangle = new Rectangle(Rectangle.X + (Rectangle.Width / 5) * 3, Rectangle.Y + (int)SizeManager.ScaleForHeight(15), Rectangle.Width / 5, (int)(Rectangle.Height * 0.6f));
                spriteBatch.Draw(Numbers[Minute < 10 ? 0 : int.Parse(Minute.ToString().Substring(0, 1))], thirdDigitRectangle, Color);

                Rectangle fourthDigitRectangle = new Rectangle(Rectangle.X + (Rectangle.Width / 5) * 4, Rectangle.Y+ (int)SizeManager.ScaleForHeight(11), Rectangle.Width / 5, (int)(Rectangle.Height * 0.6f));
                spriteBatch.Draw(Numbers[Minute < 10 ? Minute : int.Parse(Minute.ToString().Substring(1, 1))], fourthDigitRectangle, Color);
            }
        }

        public override void Update(GameTime gameTime)
        {
            if (!Enabled) return;

            Timer += gameTime.ElapsedGameTime.TotalSeconds;

            if (Timer >= SecondsBetweenMinutes)
            {
                Minute++;
                if (Minute == 60)
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
            Hour = 9;
            Minute = 0;
        }
    }
}
