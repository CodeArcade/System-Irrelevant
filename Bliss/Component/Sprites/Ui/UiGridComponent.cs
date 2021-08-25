using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Myra.Graphics2D.UI;
using System.Drawing;

namespace Bliss.Component.Sprites.Ui
{
    public class UiGridComponent : Component
    {
        public UiGridComponent(Grid grid, Size size, Vector2 position)
        {
            grid.Width = size.Width;
            grid.Height = size.Height;
            grid.Padding = new Myra.Graphics2D.Thickness((int)position.X, (int)position.Y, 0, 0);

            JamGame.Dekstop.Root = grid;
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch) { }

        public override void Update(GameTime gameTime) { }

        public override void OnRemove()
        {
            JamGame.Dekstop.Root = null;
            base.OnRemove();
        }

    }
}
