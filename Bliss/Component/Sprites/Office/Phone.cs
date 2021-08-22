using Bliss.Models;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using Color = Microsoft.Xna.Framework.Color;

namespace Bliss.Component.Sprites.Office
{
    public class Phone : Clickable
    {
        public event EventHandler OnAcceptCall;
        public event EventHandler OnEndCall;
        public event EventHandler OnMissedCall;

        private Dictionary<string, Animation> Animations { get; set; }

        private SoundEffectInstance RingingSoundEffect { get; set; }
        private double Timer { get; set; }

        public float SecondsBeforeMissedCall { get; set; } = 1;
        public bool IsRinging { get; private set; }
        public bool IsTalking { get; private set; }

        public Phone()
        {
            HoverColor = Color.Yellow;

            Texture = ContentManager.PhoneTexture;
            AnimationManager.Parent = this;
            AnimationManager.Scale = SizeManager.JamGame.HeightScaleFactor;

            Animations = new Dictionary<string, Animation>()
            {
                {
                    "idle", new Animation(ContentManager.PhoneIdleAnimation, 2) { FrameSpeed = 1f }
                },
                {
                    "ringing", new Animation(ContentManager.PhoneRingingAnimation, 2) { FrameSpeed = 0.5f }
                },
                {
                    "talking", new Animation(ContentManager.PhonePickedUpAnimation, 1)
                },
            };

            AnimationManager.Play(Animations["idle"]);
        }

        public override void Update(Microsoft.Xna.Framework.GameTime gameTime)
        {
            HoverColor = !IsRinging && !IsTalking ? Color : Color.Yellow;

            if (IsRinging)
            {
                Timer += gameTime.ElapsedGameTime.TotalSeconds;

                if (Timer >= SecondsBeforeMissedCall)
                {
                    OnMissedCall?.Invoke(this, new EventArgs());
                    IsRinging = false;
                    AnimationManager.Play(Animations["idle"]);
                    RingingSoundEffect.Stop();
                    RingingSoundEffect.Dispose();
                    Timer = 0;
                }
            }

            base.Update(gameTime);
        }

        public void Ring()
        {
            AnimationManager.Play(Animations["ringing"]);
            RingingSoundEffect = AudioManager.PlayEffect(ContentManager.PhoneRingingSoundEffect, volume: -0.5f, isLooped: true);
            SecondsBeforeMissedCall = new Random().Next(10, 21);
            IsRinging = true;
        }

        protected override void Click()
        {
            if (!IsRinging && !IsTalking) return;

            if (IsRinging)
            {
                IsRinging = false;
                IsTalking = true;
                AnimationManager.Play(Animations["talking"]);
                RingingSoundEffect.Stop();
                RingingSoundEffect.Dispose();
                AudioManager.PlayEffect(ContentManager.PhonePickUpSoundEffect);
                OnAcceptCall?.Invoke(this, new EventArgs());
            }
            else if (IsTalking)
            {
                IsTalking = false;
                AnimationManager.Play(Animations["idle"]);
                AudioManager.PlayEffect(ContentManager.PhoneHangUpSoundEffect);
                OnEndCall?.Invoke(this, new EventArgs());
            }

            base.Click();
        }

    }
}
