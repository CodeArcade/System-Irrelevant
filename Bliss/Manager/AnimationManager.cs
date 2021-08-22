using Bliss.Component;
using Bliss.Component.Sprites;
using Bliss.Models;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bliss.Manager
{
    public class AnimationManager
    {
        public Animation Animation { get; set; }
        public Rectangle AnimationRectangle => new Rectangle((int)Position.X, (int)Position.Y, (int)(Animation.FrameWidth * Scale), (int)(Animation.FrameHeight * Scale));
        public int CurrentFrame => Animation.CurrentFrame;

        private float Timer { get; set; }

        public Vector2 Position { get; set; }
        public float Scale { get; set; } = 1;
        public bool IsPlaying { get; set; }
        public bool Flip { get; set; }
        public Component.Component Parent { get; set; }
        public bool Reverse { get; set; }
        public bool FlipVertically { get; set; }
        public float Rotation { get; set; } = 0;

        public void Draw(SpriteBatch spriteBatch, Color? color = null)
        {
            if (color is null)
            {
                color = Color.White;

                if (Parent is Sprite sprite)
                    color = sprite.Color;
            }

            if (Parent != null) Position = Parent.Position;
            if (Flip)
            {
                if (FlipVertically)
                    spriteBatch.Draw(Animation.Texture, Position, new Rectangle(Animation.CurrentFrame * Animation.FrameWidth,
                                                   0,
                                                   Animation.FrameWidth,
                                                   Animation.FrameHeight), (Color)color, Rotation, Vector2.Zero, Scale, SpriteEffects.FlipHorizontally | SpriteEffects.FlipVertically, 0);
                else
                    spriteBatch.Draw(Animation.Texture, Position, new Rectangle(Animation.CurrentFrame * Animation.FrameWidth,
                                               0,
                                               Animation.FrameWidth,
                                               Animation.FrameHeight), (Color)color, Rotation, Vector2.Zero, Scale, SpriteEffects.FlipHorizontally, 0);
            }
            else
            {
                if (FlipVertically)
                    spriteBatch.Draw(Animation.Texture, Position, new Rectangle(Animation.CurrentFrame * Animation.FrameWidth,
                                               0,
                                               Animation.FrameWidth,
                                               Animation.FrameHeight), (Color)color, Rotation, Vector2.Zero, Scale, SpriteEffects.None | SpriteEffects.FlipVertically, 0);
                else
                    spriteBatch.Draw(Animation.Texture, Position, new Rectangle(Animation.CurrentFrame * Animation.FrameWidth,
                                               0,
                                               Animation.FrameWidth,
                                               Animation.FrameHeight), (Color)color, Rotation, Vector2.Zero, Scale, SpriteEffects.None, 0);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (Parent != null) Position = Parent.Position;
            Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Timer > Animation.FrameSpeed)
            {
                Timer = 0f;

                if (Reverse)
                    Animation.CurrentFrame--;
                else
                    Animation.CurrentFrame++;

                if (Animation.CurrentFrame >= Animation.FrameCount)
                {
                    if (Animation.IsLooping)
                    {
                        Animation.CurrentFrame = 0;
                    }
                    else
                    {
                        IsPlaying = false;
                    }
                }

                if (Animation.CurrentFrame < 0) Animation.CurrentFrame = Animation.FrameCount - 1;
            }
        }

        public void Play(Animation animation)
        {
            if (Animation == animation) return;
            IsPlaying = true;

            Animation = animation;

            Animation.CurrentFrame = 0;

            Timer = 0;
        }

        public void Stop()
        {
            IsPlaying = false;

            Timer = 0f;

            Animation.CurrentFrame = 0;
        }

        public void Pause()
        {
            IsPlaying = false;
        }

        public void Continue()
        {
            IsPlaying = true;
        }
    }
}