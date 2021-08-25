using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Bliss.Component.Sprites.Office.Documents
{
    public class Classified : BaseDocument
    {
        public Classified(Vector2 spawnPoint, Microsoft.Xna.Framework.Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.ClassifiedTexture;
            Size = SizeManager.GetSize(150, 150);

            Load(spawnPoint, tableArea);
        }

        public override List<Component> GetDetailViewComponents()
        {
            Size size = SizeManager.GetSize(450, 450);

            Sprite sprite = new Sprite()
            {
                Size = size,
                Position = new Vector2(
                        (int)(SizeManager.ScaleForWidth(SizeManager.JamGame.BaseWidth) - size.Width) / 2,
                        (int)(SizeManager.ScaleForHeight(SizeManager.JamGame.BaseHeight) - size.Height) / 2
                    ),
                Texture = ContentManager.ClassifiedTexture
            };

            return new List<Component>() { sprite };
        }
    }
}
