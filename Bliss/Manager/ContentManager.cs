using Microsoft.Xna.Framework.Graphics;
using Unity;

namespace Bliss.Manager
{
    public class ContentManager
    {
        [Dependency]
        public JamGame JamGame { get; set; }
        public Texture2D TableTexture => JamGame.Content.Load<Texture2D>("Sprites/Table");
    }
}
