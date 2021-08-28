using Bliss.Component.Sprites.Ui;
using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Content;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Bliss.Component.Sprites.Office.Documents
{
    public class Contract : BaseDocument
    {
        public bool HasSignature { get; set; }
        public DateTime? Date { get; set; }
        private Texture2D Signature { get; set; }

        public Contract(Vector2 spawnPoint, Microsoft.Xna.Framework.Rectangle table) : base(spawnPoint, table)
        {
            Texture = ContentManager.ContractSmallTexture;
            Size = SizeManager.GetSize(150, 200);
            Signature = ContentManager.Signatures[Random.Next(0, ContentManager.Signatures.Count)];

            HasSignature = Random.Next(0, 2) == 0;
          
            if (Random.Next(0, 2) == 0)
                Date = null;
            else
                Date = DateTime.Now.AddDays(Random.Next(-365, 1));

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
                Texture = ContentManager.ContractTexture
            };

            FontSystem fontSystem = new FontSystem();
            fontSystem.AddFont(SizeManager.JamGame.Content.OpenStream("Fonts/Arial.ttf"));

            Grid grid = new Grid();
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Width));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height / 3.5f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height / 6.5f));

            if (Date != null)
            {
                Label label = new Label()
                {
                    Text = Date.Value.ToString("dd.MM.yyyy"),
                    GridColumn = 0,
                    GridRow = 1,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(24)),
                    TextColor = Microsoft.Xna.Framework.Color.Black,
                    Padding = new Myra.Graphics2D.Thickness((int)SizeManager.ScaleForWidth(20),0,0,0)
                };
                grid.Widgets.Add(label);
            }

            Size signatureSize = SizeManager.GetSize(200, 40);
            Sprite signature = new Sprite()
            {
                Size = signatureSize,
                Position = new Vector2(sprite.Position.X + sprite.Size.Width - (signatureSize.Width * 1.2f), sprite.Position.Y + sprite.Size.Height - (signatureSize.Height * 3.2f)),
                Texture = Signature
            };

            if (HasSignature) return new List<Component>() { sprite, signature, new UiGridComponent(grid, sprite.Size, sprite.Position) };

            return new List<Component>() { sprite, new UiGridComponent(grid, sprite.Size, sprite.Position) };
        }
    }
}
