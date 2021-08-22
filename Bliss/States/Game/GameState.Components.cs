using Bliss.Component.Office;
using Bliss.Component.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Bliss.States.Game
{
    public partial class GameState
    {
        protected Table Table { get; set; }

        protected override void LoadComponents()
        {
            AddTable();
        }

        private void AddTable()
        {
            Size tableSize = GetSize(1000, 600);

            Table = new Table()
            {
                Size = tableSize,
                Position = GetPosition((JamGame.BaseWidth - tableSize.Width) / 2, (JamGame.BaseHeight - tableSize.Height) / 2)
            };
            AddComponent(Table, States.Layers.Table);
        }

        private Size GetSize(int width, int height) => new Size(width * (int)JamGame.WidthScaleFactor, height * (int)JamGame.HeightScaleFactor);
        private Vector2 GetPosition(int x, int y) => new Vector2(x * JamGame.WidthScaleFactor, y * JamGame.HeightScaleFactor);

    }
}
