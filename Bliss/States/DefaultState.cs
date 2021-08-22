using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Bliss.States
{
  public partial class DefaultState : State
  {
    public static string Name = "Default";

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
      base.Draw(gameTime, spriteBatch);
    }
  }
}