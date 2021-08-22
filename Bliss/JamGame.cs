using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Unity;
using Bliss.Manager;
using Bliss.States;
using Bliss.States.Game;

namespace Bliss
{
    public class JamGame : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;

        public int BaseWidth => 1280;
        public int BaseHeight => 720;

        public int ActualWidth => Graphics.PreferredBackBufferWidth;
        public int ActualHeight => Graphics.PreferredBackBufferHeight;

        public float WidthScaleFactor => Graphics.PreferredBackBufferWidth / BaseWidth;
        public float HeightScaleFactor => Graphics.PreferredBackBufferHeight / BaseHeight;

        [Dependency]
        public StateManager StateManager { get; set; }

        public JamGame()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Graphics.IsFullScreen = true;
            Graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            Graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            StateManager.ChangeTo<GameState>(GameState.Name);
        }

        protected override void Update(GameTime gameTime)
        {
            StateManager.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            StateManager.Draw(gameTime, SpriteBatch);
            SpriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
