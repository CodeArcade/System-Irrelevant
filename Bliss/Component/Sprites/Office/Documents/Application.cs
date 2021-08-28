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
    public enum Sexes
    {
        Male,
        Female,
        Other
    }

    public enum Countries
    {
        America,
        Germany,
        Canada,
        Sweden,
        Finland,
        UnitedKingdom,
        Norway,
        Denmark,
        Netherlands,
        Russia,
        Mexico
    }

    public class Application : BaseDocument
    {
        public Sexes Sex { get; set; }
        public Countries Country { get; set; }

        public Application(Vector2 spawnPoint, Microsoft.Xna.Framework.Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.ApplicationTexture;
            Size = SizeManager.GetSize(150, 200);

            Sex = GetSex();
            Country = GetCountry();

            Load(spawnPoint, tableArea);
        }

        private Sexes GetSex()
        {
            return Random.Next(0, 3) switch
            {
                0 => Sexes.Female,
                1 => Sexes.Male,
                _ => Sexes.Other
            };
        }

        private Countries GetCountry()
        {
            return Random.Next(0, 11) switch
            {
                0 => Countries.America,
                1 => Countries.Canada,
                2 => Countries.Denmark,
                3 => Countries.Finland,
                4 => Countries.Germany,
                5 => Countries.Mexico,
                6 => Countries.Netherlands,
                7 => Countries.Norway,
                8 => Countries.Russia,
                9 => Countries.Sweden,
                _ => Countries.UnitedKingdom,
            };
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

            FontSystem fontSystem = new FontSystem();
            fontSystem.AddFont(SizeManager.JamGame.Content.OpenStream("Fonts/Arial.ttf"));

            Grid grid = new Grid();
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Width));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height / 2f));
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, sprite.Size.Height / 2f));

            Label countryLabel = new Label()
            {
                Text = Country.ToString(),
                GridColumn = 0,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(32)),
                TextColor = Microsoft.Xna.Framework.Color.Black,
            };
            grid.Widgets.Add(countryLabel);

            Label sexLabel = new Label()
            {
                Text = Sex.ToString(),
                GridColumn = 0,
                GridRow = 1,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                VerticalAlignment = VerticalAlignment.Stretch,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(32)),
                TextColor = Microsoft.Xna.Framework.Color.Black,
            };
            grid.Widgets.Add(sexLabel);

            return new List<Component>() { sprite, new UiGridComponent(grid, sprite.Size, sprite.Position) };
        }
    }
}
