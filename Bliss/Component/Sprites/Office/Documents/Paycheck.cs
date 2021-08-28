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

    /// <summary>
    /// The only valid ones are HR, PR, R&D, IT and accounting
    /// </summary>
    public enum Departments
    {
        HumanResources,
        PublicRelations,
        ResearchDevelopment,
        IT,
        Accounting,
        Design,
        Marketing,
        Purchasing,
        Export,
        Logistics
    }

    public class Paycheck : BaseDocument
    {
        public Departments Department { get; set; }

        public Paycheck(Vector2 spawnPoint, Microsoft.Xna.Framework.Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.PaycheckSmallTexture;
            Size = SizeManager.GetSize(325 / 2, 174 / 2);

            Department = GetDepartment();

            Load(spawnPoint, tableArea);
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
            Size size = SizeManager.GetSize(700, 300);

            Sprite sprite = new Sprite()
            {
                Size = size,
                Position = new Vector2(
                        (int)(SizeManager.ScaleForWidth(SizeManager.JamGame.BaseWidth) - size.Width) / 2,
                        (int)(SizeManager.ScaleForHeight(SizeManager.JamGame.BaseHeight) - size.Height) / 2 - SizeManager.ScaleForHeight(200)
                    ),
                Texture = ContentManager.PaycheckTexture
            };

            FontSystem fontSystem = new FontSystem();
            fontSystem.AddFont(SizeManager.JamGame.Content.OpenStream("Fonts/Arial.ttf"));

            Grid grid = new Grid();
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Width));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height / 3));
            grid.RowsProportions.Add(new Proportion(ProportionType.Auto));
            Label headerLabel = new Label()
            {
                Text = $"NOT IRIGATEX CORP{Environment.NewLine}1600 Pennsylvania{Environment.NewLine}Washington, DC 20500",
                GridColumn = 0,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(20)),
                TextColor = Microsoft.Xna.Framework.Color.Black,
                Padding = new Myra.Graphics2D.Thickness((int)SizeManager.ScaleForWidth(25), (int)SizeManager.ScaleForHeight(30), 0, 0)
            };
            grid.Widgets.Add(headerLabel);

            Label departmentLabel = new Label()
            {
                Text = $"Pay against this check {Environment.NewLine}To: {Department}{Environment.NewLine}{Environment.NewLine}{Random.Next(2000, 5001)} $",
                GridColumn = 0,
                GridRow = 1,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(24)),
                TextColor = Microsoft.Xna.Framework.Color.Black,
                Padding = new Myra.Graphics2D.Thickness((int)SizeManager.ScaleForWidth(40), (int)SizeManager.ScaleForHeight(20), 0, 0)
            };
            grid.Widgets.Add(departmentLabel);

            return new List<Component>() { sprite, new UiGridComponent(grid, sprite.Size, sprite.Position) };
        }

    }
}
