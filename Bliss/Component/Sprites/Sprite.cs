using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Bliss.Component.Sprites
{
  public class Sprite : Component
  {
    private Size InternalSize { get; set; }

    public float Speed { get; set; }
    public Vector2 Direction { get; set; }
    public Texture2D Texture { get; set; }
    public Color Color { get; set; } = Color.White;
    public bool Collide { get; set; } = true;

    public Size Size
    {
      get
      {
        if (InternalSize == Size.Empty)
        {
          if (AnimationManager.IsPlaying)
            InternalSize = new Size((int)(AnimationManager.AnimationRectangle.Width), (int)(AnimationManager.AnimationRectangle.Height));
          else
            InternalSize = new Size((int)(Texture.Width), (int)(Texture.Height));
        }
        return InternalSize;
      }
      set
      {
        InternalSize = value;
      }
    }

    public Rectangle Rectangle
    {
      get
      {
        Rectangle rectangle;

        if (AnimationManager.IsPlaying)
        {
          rectangle = AnimationManager.AnimationRectangle;
          rectangle.Width = Size.Width;
          rectangle.Height = Size.Height;
        }
        else
          rectangle = new Rectangle((int)Position.X, (int)Position.Y, Size.Width, Size.Height);

        return rectangle;
      }
    }

    public int HitBoxXOffSet { get; set; }
    public int HitBoxYOffSet { get; set; }
    public Size HitboxSize { get; set; }

    public Rectangle Hitbox
    {
      get
      {
        if (HitboxSize == Size.Empty)
          return new Rectangle((int)Position.X + HitBoxXOffSet, (int)Position.Y + HitBoxYOffSet, Size.Width, Size.Height);
        else
          return new Rectangle((int)Position.X + HitBoxXOffSet, (int)Position.Y + HitBoxYOffSet, HitboxSize.Width, HitboxSize.Height);
      }
    }

    public Vector2 Center => new Vector2(Position.X + (Size.Width / 2), Position.Y + (Size.Height / 2));

    public virtual void OnCollision(Sprite sprite, GameTime gameTime)
    {
    }

    #region Collision

    protected bool IsTouchingRight(Sprite sprite)
    {
      if (!Collides(sprite)) return false;

      int distanceRight = Math.Abs(Hitbox.Left - sprite.Hitbox.Right);
      int distanceLeft = Math.Abs(Hitbox.Right - sprite.Hitbox.Left);

      int distanceTop = Math.Abs(Hitbox.Top - sprite.Hitbox.Bottom);
      int distanceBottom = Math.Abs(Hitbox.Bottom - sprite.Hitbox.Top);

      return distanceRight < distanceLeft && distanceRight < distanceTop && distanceRight < distanceBottom;
    }

    protected bool IsTouchingLeft(Sprite sprite)
    {
      if (!Collides(sprite)) return false;

      int distanceRight = Math.Abs(Hitbox.Left - sprite.Hitbox.Right);
      int distanceLeft = Math.Abs(Hitbox.Right - sprite.Hitbox.Left);

      int distanceTop = Math.Abs(Hitbox.Top - sprite.Hitbox.Bottom);
      int distanceBottom = Math.Abs(Hitbox.Bottom - sprite.Hitbox.Top);

      return distanceLeft < distanceRight && distanceLeft < distanceTop && distanceLeft < distanceBottom;
    }

    protected bool IsTouchingBottom(Sprite sprite)
    {
      if (!Collides(sprite)) return false;

      int distanceRight = Math.Abs(Hitbox.Right - sprite.Hitbox.Left);
      int distanceLeft = Math.Abs(Hitbox.Left - sprite.Hitbox.Right);

      int distanceTop = Math.Abs(Hitbox.Top - sprite.Hitbox.Bottom);
      int distanceBottom = Math.Abs(Hitbox.Bottom - sprite.Hitbox.Top);

      return distanceTop < distanceLeft && distanceTop < distanceBottom && distanceTop < distanceRight;
    }

    protected bool IsTouchingTop(Sprite sprite)
    {
      if (!Collides(sprite)) return false;

      int distanceRight = Math.Abs(Hitbox.Right - sprite.Hitbox.Left);
      int distanceLeft = Math.Abs(Hitbox.Left - sprite.Hitbox.Right);

      int distanceTop = Math.Abs(Hitbox.Top - sprite.Hitbox.Bottom);
      int distanceBottom = Math.Abs(Hitbox.Bottom - sprite.Hitbox.Top);

      return distanceBottom < distanceLeft && distanceBottom < distanceTop && distanceBottom < distanceRight;
    }

    private bool Collides(Sprite sprite)
    {
      return Hitbox.Intersects(sprite.Hitbox);
    }

    #endregion

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      if (AnimationManager.IsPlaying)
        AnimationManager.Draw(spriteBatch);
      else
        spriteBatch.Draw(Texture, Rectangle, Color);

      ParticleManager.Draw(gameTime, spriteBatch);
    }

    public override void Update(GameTime gameTime)
    {
      AudioManager.Update();
      ParticleManager.Update(gameTime);

      if (AnimationManager.IsPlaying) AnimationManager.Update(gameTime);
    }

    public Sprite Copy()
    {
      return (Sprite)this.MemberwiseClone();
    }

    public T Copy<T>()
    {
      return (T)this.MemberwiseClone();
    }
  }
}
