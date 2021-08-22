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
    public float Scale { get; set; }
    public bool IsPlaying { get; set; }
    public bool FlipHorizontally { get; set; }
    public bool FlipVertically { get; set; }
    public Component.Component Parent { get; set; }
    public bool Reverse { get; set; }
    public float Rotation { get; set; }

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
      Animation.CurrentFrame = 0; // Potentially cut this?
    }

    public void Pause()
    {
      IsPlaying = false;
    }

    public void Continue()
    {
      IsPlaying = true;
    }

    public void Draw(SpriteBatch spriteBatch, Color? color = null)
    {
      if (color is null)
      {
        color = Parent is Sprite sprite ? sprite.Color : Color.White;
      }

      if (!(Parent is null)) Position = Parent.Position;

      SpriteEffects flip = (FlipHorizontally) ? SpriteEffects.FlipHorizontally : SpriteEffects.None
      | (FlipVertically ? SpriteEffects.FlipVertically : SpriteEffects.None);
      spriteBatch.Draw(Animation.Texture, Position, new Rectangle(Animation.CurrentFrame * Animation.FrameWidth, 0, Animation.FrameWidth, Animation.FrameHeight),
      (Color)color, Rotation, Vector2.Zero, Scale, flip, 0);
    }

    public void Update(GameTime gameTime)
    {
      if (!(Parent is null)) Position = Parent.Position;
      Timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

      if (Timer > Animation.FrameSpeed)
      {
        Timer = 0f;

        Animation.CurrentFrame += Reverse ? -1 : 1;
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

        if (Animation.CurrentFrame < 0)
        {
          Animation.CurrentFrame = Animation.FrameCount - 1;
        }
      }
    }
  }
}