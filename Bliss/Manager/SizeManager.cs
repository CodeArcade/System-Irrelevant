using Microsoft.Xna.Framework;
using System.Drawing;
using Unity;

namespace Bliss.Manager
{
    public class SizeManager
    {
        [Dependency]
        public JamGame JamGame { get; set; }

        public Size GetSize(int width, int height) => new Size((int)(width * JamGame.WidthScaleFactor), (int)(height * JamGame.HeightScaleFactor));
        public Vector2 GetPosition(int x, int y) => new Vector2(x * JamGame.WidthScaleFactor, y * JamGame.HeightScaleFactor);
        public float ScaleForWidth(int width) => width * JamGame.WidthScaleFactor;
        public float ScaleForHeight(int height) => height * JamGame.HeightScaleFactor;
    }
}
