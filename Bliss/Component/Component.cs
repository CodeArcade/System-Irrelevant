using System;
using Unity;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bliss.Manager;
using Bliss.States;

namespace Bliss.Component
{
    public abstract class Component
    {
        #region Dependencies

        public AnimationManager AnimationManager { get; set; } = new AnimationManager();
        public ContentManager ContentManager => Program.UnityContainer.Resolve<ContentManager>();
        public AudioManager AudioManager => Program.UnityContainer.Resolve<AudioManager>();
        public ParticleManager ParticleManager => Program.UnityContainer.Resolve<ParticleManager>();
        public SizeManager SizeManager => Program.UnityContainer.Resolve<SizeManager>();
        #endregion

        #region Private Properties

        private Vector2 InternalPosition { get; set; }

        #endregion

        #region Public Properties

        public bool Visible { get; set; } = true;

        public State CurrentState { get; set; }

        public Vector2 Position
        {
            get => InternalPosition;
            set
            {
                InternalPosition = value;
            }
        }

        public bool IsRemoved { get; set; }
        public Component Parent { get; set; }

        #endregion

        protected float DistanceTo(Component component) => DistanceTo(component.Position);

        protected Vector2 DirectionTo(Component component) => DirectionTo(component.Position);

        protected float AngleTo(Component component) => AngleTo(component.Position);

        protected float DistanceTo(Vector2 position) => Vector2.Distance(Position, position);

        protected Vector2 DirectionTo(Vector2 position)
        {
            Vector2 direction = position - Position;
            direction.Normalize();

            return direction;
        }

        protected float AngleTo(Vector2 position) => (float)Math.Atan2(position.Y - Position.Y, position.X - Position.X);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void Update(GameTime gameTime);

        public virtual void OnRemove() { }
    }
}
