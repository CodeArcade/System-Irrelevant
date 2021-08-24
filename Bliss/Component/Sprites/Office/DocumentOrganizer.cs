using Bliss.Component.Sprites.Office.Documents;
using Bliss.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MonoGame.Extended.Tweening;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended;
using System.Diagnostics;

namespace Bliss.Component.Sprites.Office
{
    public enum OrganizerIds
    {
        Green,
        Red,
        Blue,
        Bin
    }

    public class DocumentOrganizer : Clickable
    {
        public OrganizerIds Id { get; set; }
        public List<Func<BaseDocument, bool>> Validators { get; set; } = new List<Func<BaseDocument, bool>>();
        private readonly Tweener Tweener = new Tweener();
        public Vector2 OriginPosition { get; set; }
        public int TweenOffset { get; set; }

        private bool IsExtending { get; set; } = false;
        private bool IsRetracting { get; set; } = false;

        public bool Validate(BaseDocument document)
        {
            foreach (Func<BaseDocument, bool> validator in Validators)
            {
                if (!validator.Invoke(document)) return false;
            }

            return true;
        }

        public override void Update(GameTime gameTime)
        {
            UpdateHover();
            Tweener.Update(gameTime.GetElapsedSeconds());
            base.Update(gameTime);
        }

        public void UpdateHover()
        {
            CurrentMouse = Mouse.GetState();
            if (IsMouseOverOrganizer() && !IsExtending)
            {
                Extend();
            }

            if (!IsMouseOverOrganizer() && !IsRetracting)
            {
                Retract();
            }
        }

        private bool IsMouseOverOrganizer()
        {
            Rectangle mouseRectangle = new Rectangle(CurrentMouse.X, CurrentMouse.Y, 1, 1);
            return mouseRectangle.Intersects(Rectangle);
        }

        public void Extend() 
        {
            Tweener.TweenTo(target: this, duration: 0.3f, expression: organizer => organizer.Position, toValue: new Vector2(OriginPosition.X - TweenOffset, OriginPosition.Y))
                .Easing(EasingFunctions.CircleOut);
            IsExtending = true;
            IsRetracting = false;
        }

        public void Retract()
        {
            Tweener.TweenTo(target: this, duration: 0.3f, expression: organizer => organizer.Position, toValue: new Vector2(OriginPosition.X, OriginPosition.Y))
                .Easing(EasingFunctions.CircleOut);
            IsRetracting = true;
            IsExtending = false;
        }
    }
}
