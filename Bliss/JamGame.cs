using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Unity;
using Bliss.Manager;
using Bliss.States;
using Bliss.States.Game;
using Myra.Graphics2D.UI;

namespace Bliss
{
    public class JamGame : Game
    {
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;

        public static Desktop Dekstop;

        public int BaseWidth => 1280;
        public int BaseHeight => 720;

        public int ActualWidth => Graphics.PreferredBackBufferWidth;
        public int ActualHeight => Graphics.PreferredBackBufferHeight;

        public float WidthScaleFactor => (float)Graphics.PreferredBackBufferWidth / (float)BaseWidth;
        public float HeightScaleFactor => (float)Graphics.PreferredBackBufferHeight / (float)BaseHeight;

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
            // this should work - but no dynamic resize

            Graphics.IsFullScreen = true;
            Graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            Graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            //Graphics.IsFullScreen = false;
            //Graphics.PreferredBackBufferWidth = BaseWidth;
            //Graphics.PreferredBackBufferHeight = BaseHeight;

            //Graphics.IsFullScreen = false;
            //Graphics.PreferredBackBufferWidth = 720;
            //Graphics.PreferredBackBufferHeight = 480;

            //Graphics.IsFullScreen = false;
            //Graphics.PreferredBackBufferWidth = 1400;
            //Graphics.PreferredBackBufferHeight = 654;

            Graphics.ApplyChanges();

            Dekstop = new Desktop();
            Myra.MyraEnvironment.Game = this;

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
            GraphicsDevice.Clear(Color.LightBlue);

            SpriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);
            StateManager.Draw(gameTime, SpriteBatch);
            SpriteBatch.End();

            Dekstop.Render();

            base.Draw(gameTime);
        }
    }
}
