using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Bliss.Component.Sprites.Office.Documents
{
    public class Application : BaseDocument
    {
        public DateTime Birthday { get; set; }
        public bool? Sex { get; set; }
        public string Address { get; set; }

        public Application(Vector2 spawnPoint, Microsoft.Xna.Framework.Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.ApplicationTexture;
            Size = SizeManager.GetSize(150, 200);

            Load(spawnPoint, tableArea);
        }

        public override List<Component> GetDetailViewComponents()
        {
            Size size = SizeManager.GetSize(450, 600);

            Sprite sprite = new Sprite()
            {
                Size = size,
                Position = new Vector2(
                        (int)(SizeManager.ScaleForWidth(SizeManager.JamGame.BaseWidth) - size.Width) / 2,
                        (int)(SizeManager.ScaleForHeight(SizeManager.JamGame.BaseHeight) - size.Height) / 2
                    ),
                Texture = ContentManager.ApplicationTexture
            };

            return new List<Component>() { sprite };
        }
    }
}
