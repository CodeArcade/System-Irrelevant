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
        public List<Rule> Validators { get; set; } = new List<Rule>();
        private readonly Tweener Tweener = new Tweener();
        public Vector2 OriginPosition { get; set; }
        public int TweenOffset { get; set; }

        public bool CanHover { get; set; } = true;

        private bool IsExtending { get; set; } = false;
        private bool IsRetracting { get; set; } = false;

        private MouseState TweenerCurrentMouse { get; set; }
        
        private PlayerStats PlayerStats { get; set; }

        public DocumentOrganizer(PlayerStats playerStats)
        {
            PlayerStats = playerStats;
        }

        public bool Validate(BaseDocument document)
        {
            foreach (Rule rule in Validators)
            {
                if (!rule.Validate(document)) return false;
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
            if (!CanHover) return;
            if (!IsMouseInsideWindow()) return;
            TweenerCurrentMouse = Mouse.GetState();
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
            Rectangle mouseRectangle = new Rectangle(TweenerCurrentMouse.X, TweenerCurrentMouse.Y, 1, 1);
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
            Tweener.TweenTo(target: this, duration: 0.3f, expression: organizer => organizer.Position, toValue: OriginPosition)
                .Easing(EasingFunctions.CircleOut);
            IsRetracting = true;
            IsExtending = false;
        }

        public override void OnCollision(Sprite sprite, GameTime gameTime)
        {
            if (!IsExtending) return;
            
            if (sprite is BaseDocument document)
            {
                if (document.IsHeld) return;
                if (document.TimeSinceHeld > 0.1) return;
                if (document.IsRemoved) return;

                OnDrop(document);
            }
        }

        public void OnDrop(BaseDocument document)
        {
            if (!Validate(document)) PlayerStats.WronglySortedDocuments++;

            AudioManager.PlayEffect(ContentManager.DocumentPutDownSoundEffect);
            document.IsRemoved = true;
        }

        protected override void Click() { }

    }
}
