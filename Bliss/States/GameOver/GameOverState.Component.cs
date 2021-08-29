using Bliss.Component.Sprites;
using Bliss.States.Game;
using FontStashSharp;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Content;
using Myra.Graphics2D.UI;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;

namespace Bliss.States.GameOver
{
    public partial class GameOverState : State
    {
        protected override void LoadComponents()
        {
            FontSystem fontSystem = new FontSystem();
            fontSystem.AddFont(JamGame.Content.OpenStream("Fonts/Arial.ttf"));

            Grid grid = new Grid()
            {
                ColumnSpacing = 8,
                RowSpacing = 8
            };
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForWidth(JamGame.BaseWidth / 3)));
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Fill));
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForWidth(JamGame.BaseWidth / 3)));

            // Spacer
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.3))));
            // Title
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Subtitle
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Spacer
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.25))));
            // Button
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Spacer
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.3))));

            Size backgroundSize = SizeManager.GetSize(JamGame.BaseWidth, JamGame.BaseHeight);
            Sprite backgroundSprite = new Sprite()
            {
                Position = SizeManager.GetPosition(0, 0),
                Texture = ContentManager.BackgroundTexture,
                Size = SizeManager.GetSize(JamGame.ActualWidth, JamGame.ActualHeight)
            };
            AddComponent(backgroundSprite, States.Layers.Background);

            Label title = new Label()
            {
                Text = "GAME OVER",
                GridColumn = 1,
                GridRow = 1,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(64)),
                TextColor = Color.Red
            };
            grid.Widgets.Add(title);

            Label subTitle = new Label()
            {
                Text = "You got fired!",
                GridColumn = 1,
                GridRow = 2,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(32)),
                TextColor = Color.Black,
                Padding = new Myra.Graphics2D.Thickness(0, (int)SizeManager.ScaleForHeight(30), 0, 0)
            };
            grid.Widgets.Add(subTitle);

            TextButton button = new TextButton
            {
                Text = "Play Again",
                GridColumn = 1,
                GridRow = 4,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(16)),
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = (int)SizeManager.ScaleForWidth(JamGame.BaseWidth / 6),
                VerticalAlignment = VerticalAlignment.Stretch
            };
            button.Click += (sender, e) => { AudioManager.StopMusic(); StateManager.ChangeTo<MenuState>(MenuState.Name); };
            grid.Widgets.Add(button);

            JamGame.Dekstop.Root = grid;
        }
    }
}
