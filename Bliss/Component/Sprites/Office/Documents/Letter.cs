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
    public class Letter : BaseDocument
    {
        public bool HasStamp { get; set; }
        public string ReturnAddress { get; set; }

        public Letter(Vector2 spawnPoint, Microsoft.Xna.Framework.Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.LetterTexture;
            Size = SizeManager.GetSize(200, 100);
            
            HasStamp = Random.Next(0, 2) == 0;
            ReturnAddress = Random.Next(0, 2) == 0 ? "" : GetReturnAddress();

            Load(spawnPoint, tableArea);
        }

        private string GetReturnAddress()
        {
            return Random.Next(0, 7) switch
            {
                0 => $"THE ROBINSONS{Environment.NewLine}5122 CENTER PARK DRIVE{Environment.NewLine}BOSTON, MA 02166",
                1 => $"Alexandra Harrington{Environment.NewLine}123 Your Street{Environment.NewLine}Yourtown, XX 12345",
                2 => $"WHITEPETALS{Environment.NewLine}1234 Daisy Lane{Environment.NewLine}Yourtown, XX 72203",
                3 => $"CHARLES ADKINS{Environment.NewLine}123 Plain orange road{Environment.NewLine}Generic city, State Zip",
                4 => $"THE THOMPSON FAMILIY{Environment.NewLine}901 North Avenue{Environment.NewLine}Sacramento, CA 95841",
                5 => $"Santa Claus{Environment.NewLine}123 Elf Road{Environment.NewLine}North Pole 88888",
                _ => $"Spartakus{Environment.NewLine}Piazza del Colosseo 1{Environment.NewLine}RM, Italia",
            };
        }

        public override List<Component> GetDetailViewComponents()
        {
            Size size = SizeManager.GetSize(600, 300);

            Sprite sprite = new Sprite()
            {
                Size = size,
                Position = new Vector2(
                        (int)(SizeManager.ScaleForWidth(SizeManager.JamGame.BaseWidth) - size.Width) / 2,
                        (int)(SizeManager.ScaleForHeight(SizeManager.JamGame.BaseHeight) - size.Height) / 2
                    ),
                Texture = ContentManager.LetterTexture
            };


            FontSystem fontSystem = new FontSystem();
            fontSystem.AddFont(SizeManager.JamGame.Content.OpenStream("Fonts/Arial.ttf"));

            Grid grid = new Grid();
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Width));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height));

            Label addressLabel = new Label()
            {
                Text = ReturnAddress,
                GridColumn = 0,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(32)),
                TextColor = Microsoft.Xna.Framework.Color.Black,
            };
            grid.Widgets.Add(addressLabel);

            Size stampSize = SizeManager.GetSize(100, 100);
            Sprite stamp = new Sprite()
            {
                Size = stampSize,
                Position = new Vector2(sprite.Position.X, sprite.Position.Y + sprite.Size.Height - stampSize.Height),
                Texture = ContentManager.StickyNoteTexture
            };

            if (HasStamp) return new List<Component>() { sprite, stamp, new UiGridComponent(grid, sprite.Size, sprite.Position) };

            return new List<Component>() { sprite, new UiGridComponent(grid, sprite.Size, sprite.Position) };
        }
    }
}
