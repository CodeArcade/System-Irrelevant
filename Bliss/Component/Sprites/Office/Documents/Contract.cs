using Bliss.Component.Sprites.Ui;
using FontStashSharp;
using Microsoft.Xna.Framework;
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

        public Contract(Vector2 spawnPoint, Microsoft.Xna.Framework.Rectangle table) : base(spawnPoint, table)
        {
            Texture = ContentManager.ContractTexture;
            Size = SizeManager.GetSize(150, 200);

            HasSignature = Random.Next(0, 2) == 0;

            if (Random.Next(0, 2) == 0)
                Date = null;
            else
                Date = DateTime.Now.AddDays(Random.Next(0, 10));

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
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height / 2f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height / 2f));

            if (Date != null)
            {
                Label label = new Label()
                {
                    Text = Date.Value.ToString("dd.MM.yyyy"),
                    GridColumn = 0,
                    GridRow = 0,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(32)),
                    TextColor = Microsoft.Xna.Framework.Color.Black,
                };
                grid.Widgets.Add(label);
            }

            if (HasSignature)
            {
                Label label = new Label()
                {
                    Text = "H. Meier",
                    GridColumn = 0,
                    GridRow = 1,
                    HorizontalAlignment = HorizontalAlignment.Stretch,
                    VerticalAlignment = VerticalAlignment.Stretch,
                    Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(32)),
                    TextColor = Microsoft.Xna.Framework.Color.Black,
                };
                grid.Widgets.Add(label);
            }

            UiGridComponent uiGridComponent = new UiGridComponent(grid, sprite.Size, sprite.Position);

            return new List<Component>() { sprite, uiGridComponent };
        }
    }
}
