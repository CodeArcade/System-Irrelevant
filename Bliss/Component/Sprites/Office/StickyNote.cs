using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using MonoGame.Extended.Tweening;
using Bliss.Models;
using Size = System.Drawing.Size;
using MonoGame.Extended;

namespace Bliss.Component.Sprites.Office
{
    public class StickyNote : Clickable
    {
        public Vector2 OriginPosition { get; set; }
        public int TweenOffset { get; set; }
        private readonly Tweener Tweener = new Tweener();

        private bool IsExtending { get; set; } = false;
        private bool IsRetracting { get; set; } = false;

        public List<Rule> ActiveRules { get; set; } = new List<Rule>();

        public StickyNote() : base()
        {
            Texture = ContentManager.StickyNoteTexture;
            Size = SizeManager.GetSize(Texture.Width, Texture.Height);
        }

        public void Extend()
        {
            Tweener.TweenTo(target: this, duration: 0.3f, expression: note => note.Position, toValue: new Vector2(OriginPosition.X, OriginPosition.Y + TweenOffset))
                .Easing(EasingFunctions.CircleOut);
            IsExtending = true;
            IsRetracting = false;
        }

        public void Retract()
        {
            Tweener.TweenTo(target: this, duration: 0.3f, expression: organizer => organizer.Position, toValue: OriginPosition)
                .Easing(EasingFunctions.CircleOut);
            IsRetracting = true;
            IsExtending = false;
        }

        public override void Update(GameTime gameTime)
        {
            Tweener.Update(gameTime.GetElapsedSeconds());
            base.Update(gameTime);
        }

        // todo draw:
        // render all active rules on enlarged stickynote
        // HELP IT NO DRAW :(
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public List<Component> GetDetailViewComponents()
        {
            Size size = SizeManager.GetSize(450, 600);

            Sprite sprite = new Sprite()
            {
                Size = size,
                Position = new Vector2(
                    (int)(SizeManager.ScaleForWidth(SizeManager.JamGame.BaseWidth) - size.Width),
                    (int)(SizeManager.ScaleForHeight(SizeManager.JamGame.BaseHeight) - size.Height)
                ),
                Texture = ContentManager.StickyNoteTexture
            };

            return new List<Component> { sprite };
        }
    }
}
