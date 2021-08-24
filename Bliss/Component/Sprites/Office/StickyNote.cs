using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using MonoGame.Extended.Tweening;

namespace Bliss.Component.Sprites.Office
{
    public class StickyNote : Sprite
    {
        public Vector2 OriginPosition { get; set; }
        public int TweenOffset { get; set; }
        private readonly Tweener Tweener = new Tweener();

        private bool IsExtending { get; set; } = false;
        private bool IsRetracting { get; set; } = false;

        public StickyNote() : base()
        {
            Texture = ContentManager.StickyNoteTexture;
        }

        public void Extend()
        {
            Tweener.TweenTo(target: this, duration: 0.3f, expression: note => note.Position, toValue: new Vector2(OriginPosition.X, OriginPosition.Y - TweenOffset))
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
    }
}
