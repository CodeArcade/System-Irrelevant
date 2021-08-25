using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Bliss.Component.Sprites.Office.Documents
{
    public class Contract : BaseDocument
    {
        public Contract(Vector2 spawnPoint, Microsoft.Xna.Framework.Rectangle table) : base(spawnPoint, table)
        {
            Texture = ContentManager.InvoiceTexture;
            Size = SizeManager.GetSize(150, 200);

            Load(spawnPoint, table);
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
                Texture = ContentManager.InvoiceTexture
            };

            return new List<Component>() { sprite };
        }
    }
}
