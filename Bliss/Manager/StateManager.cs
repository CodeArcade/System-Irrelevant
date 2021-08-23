using Bliss.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace Bliss.Manager
{
    public class StateManager
    {
        public static State CurrentState { get; private set; }
        private static State NextState { get; set; }
        private static string StateName { get; set; }
        private object[] Parameter { get; set; }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch) => CurrentState.Draw(gameTime, spriteBatch);

        public void Update(GameTime gameTime)
        {
            ChangeState();
            if (CurrentState.HasLoaded)
            {
                CurrentState.Update(gameTime);
                CurrentState.PostUpdate(gameTime);
            }
        }

        private void ChangeState()
        {
            if (NextState is null) return;
            if (NextState == CurrentState) return;
            if (!NextState.HasLoaded) NextState.Load(Parameter);

            CurrentState = NextState;
            NextState = null;
        }

        public void ChangeTo<T>(string name, params object[] parameter) where T : State
        {
            NextState = (T)Program.UnityContainer.Resolve(typeof(T), StateName);
            StateName = name;
            Parameter = parameter.ToList().ToArray();
        }

        public void Reload() => NextState = (State)Program.UnityContainer.Resolve(CurrentState.GetType(), StateName);

    }
}
