using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Unity;

namespace Bliss.Manager
{
    public class SizeManager
    {
        [Dependency]
        public JamGame JamGame { get; set; }

        public Size GetSize(int width, int height) => new Size(width * (int)JamGame.WidthScaleFactor, height * (int)JamGame.HeightScaleFactor);
        public Vector2 GetPosition(int x, int y) => new Vector2(x * (int)JamGame.WidthScaleFactor, y * (int)JamGame.HeightScaleFactor);
        public float ScaleForWidth(int width) => width * (int)JamGame.WidthScaleFactor;
        public float ScaleForHeight(int height) => height * (int)JamGame.HeightScaleFactor;
    }
}
