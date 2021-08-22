using System;
using System.Collections.Generic;
using Unity;
using Bliss.Manager;
using Bliss.Component.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Bliss.States
{
    public enum Layers
    {
        Background,
        Table,
        PlayingArea,
        DocumentDetailView,
        UI,
        SceneTransition
    }

    public class State
    {
        #region Fields

        public List<Component.Component>[] Layers { get; set; }
        [Dependency]
        public ContentManager ContentManager { get; set; }

        [Dependency]
        public StateManager stateManager { get; set; }

        [Dependency]
        public JamGame JamGame { get; set; }

        [Dependency]
        public AudioManager AudioManager { get; set; }
        [Dependency]
        public SizeManager SizeManager { get; set; }
        public bool HasLoaded { get; set; }

        #endregion

        #region Methods

        public void Load(params object[] parameter)
        {
            Layers = new List<Component.Component>[Enum.GetNames(typeof(Layers)).Length];
            for (int i = 0; i < Layers.Length; i++)
            {
                Layers[i] = new List<Component.Component>();
            }
            LoadComponents();
            OnLoad(parameter);
            HasLoaded = true;
        }

        protected virtual void LoadComponents() { }
        protected virtual void OnLoad(params object[] parameter) { }

        public virtual void AddComponent(Component.Component component, int layer)
        {
            component.CurrentState = this;
            Layers[layer].Add(component);
        }

        public virtual void AddComponent(Component.Component component, Layers layer)
        {
            AddComponent(component, (int)layer);
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Layers.All(l => l.Count == 0)) return;

            for (int layer = 0; layer < Layers.Length; layer++)
            {
                List<Component.Component> drawOrder = Layers[layer].OrderByDescending(c => c.Position.Y).ToList();

                for (int i = drawOrder.Count; i > 0; i--)
                {
                    if (drawOrder[i - 1].Visible)
                    {
                        drawOrder[i- 1].Draw(gameTime, spriteBatch);
                    }
                }
            }
        }

        public virtual void PostUpdate(GameTime gameTime)
        {
            if (Layers.All(l => l.Count == 0)) return;

            foreach (List<Component.Component> components in Layers)
            {
                for (int i = components.Count - 1; i >= 0; i--)
                {
                    if (components[i].IsRemoved)
                    {
                        components[i].OnRemove();
                        components.RemoveAt(i);
                    }
                }
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            AudioManager.Update();
            if (Layers.All(l => l.Count == 0)) return;

            List<Component.Component> allComponents = Layers.SelectMany(x => x).ToList();

            for (int i = allComponents.Count - 1; i >= 0; i--)
            {
                allComponents[i].Update(gameTime);
            }

            CollisionCheck(gameTime);
        }

        private void CollisionCheck(GameTime gameTime)
        {
            List<Sprite> sprites = Layers[(int)States.Layers.PlayingArea].Where(x => x is Sprite).Select(x => x as Sprite).ToList();

            foreach (Sprite sprite in sprites)
            {
                if (!sprite.Collide) continue;
                foreach (Sprite other in sprites)
                {
                    if (!other.Collide) continue;
                    if (sprite == other) continue;
                    if (sprite.Rectangle.Intersects(other.Rectangle))
                    {
                        sprite.OnCollision(other, gameTime);
                        other.OnCollision(sprite, gameTime);
                    }
                }
            }
        }

        #endregion
    }
}
