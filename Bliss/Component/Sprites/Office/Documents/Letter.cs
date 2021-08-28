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
        public string SenderAddress { get; set; }

        public Letter(Vector2 spawnPoint, Microsoft.Xna.Framework.Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.LetterSmallTexture;
            Size = SizeManager.GetSize(275 / 2, 174 / 2);

            HasStamp = Random.Next(0, 2) == 0;
            ReturnAddress = Random.Next(0, 2) == 0 ? "" : GetReturnAddress();
            SenderAddress = GetSenderAddress();
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

        private string GetSenderAddress()
        {
            return $"NOT IRIGATEX CORP{Environment.NewLine}{GetDepartment()}{Environment.NewLine}1600 Pennsylvania{Environment.NewLine}Washington, DC 20500";
        }

        private Departments GetDepartment()
        {
            return Random.Next(0, 10) switch
            {
                0 => Departments.Accounting,
                1 => Departments.Design,
                2 => Departments.Export,
                3 => Departments.HumanResources,
                4 => Departments.IT,
                5 => Departments.Logistics,
                6 => Departments.Marketing,
                7 => Departments.PublicRelations,
                8 => Departments.Purchasing,
                _ => Departments.ResearchDevelopment
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
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, size.Height));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, size.Width / 2));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));

            Label addressLabel = new Label()
            {
                Text = ReturnAddress,
                GridColumn = 0,
                GridRow = 0,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(20)),
                TextColor = Microsoft.Xna.Framework.Color.Black,
                Padding = new Myra.Graphics2D.Thickness((int)SizeManager.ScaleForWidth(25), (int)SizeManager.ScaleForHeight(20), 0, 0)
            };
            grid.Widgets.Add(addressLabel);

            Label senderLabel = new Label()
            {
                Text = SenderAddress,
                GridColumn = 0,
                GridRow = 1,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(20)),
                TextColor = Microsoft.Xna.Framework.Color.Black,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
            };
            grid.Widgets.Add(senderLabel);

            Size stampSize = SizeManager.GetSize(75, 75);
            Sprite stamp = new Sprite()
            {
                Size = stampSize,
                Position = new Vector2(sprite.Position.X + sprite.Size.Width - stampSize.Width - SizeManager.ScaleForWidth(28), sprite.Position.Y + SizeManager.ScaleForHeight(20)),
                Texture = ContentManager.LetterStampTexture
            };

            if (HasStamp) return new List<Component>() { stamp, new UiGridComponent(grid, sprite.Size, sprite.Position), sprite };

            return new List<Component>() { new UiGridComponent(grid, sprite.Size, sprite.Position), sprite };
        }
    }
}
