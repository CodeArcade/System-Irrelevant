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
    public partial class MenuState : State
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
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.1))));
            // Sound
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Tutorial
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Spacer
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.1))));
            // Button
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Button
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Spacer
            grid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.25))));

            Size titleSize = SizeManager.GetSize(1501 / 3, 746 / 3);
            Sprite titleSprite = new Sprite()
            {
                Position = SizeManager.GetPosition((JamGame.BaseWidth - 1501 / 3) / 2, 50),
                Texture = ContentManager.TitleTexture,
                Size = titleSize
            };
            AddComponent(titleSprite, States.Layers.UI);

            Size backgroundSize = SizeManager.GetSize(JamGame.BaseWidth, JamGame.BaseHeight);
            Sprite backgroundSprite = new Sprite()
            {
                Position = SizeManager.GetPosition(0, 0),
                Texture = ContentManager.BackgroundTexture,
                Size = SizeManager.GetSize(JamGame.ActualWidth, JamGame.ActualHeight)
            };
            AddComponent(backgroundSprite, States.Layers.Background);

            Grid soundGrid = new Grid()
            {
                ColumnSpacing = 8,
                RowSpacing = 8,
                GridColumn = 1,
                GridRow = 4,
            };
            soundGrid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForWidth(JamGame.BaseWidth / 6)));
            soundGrid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForWidth(JamGame.BaseWidth / 6)));
            soundGrid.RowsProportions.Add(new Proportion(ProportionType.Fill));

            ComboBox soundCombobox = new ComboBox()
            {
                GridColumn = 1,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
            };
            for (int i = 0; i < 10; i++) soundCombobox.Items.Add(new ListItem($"{(i + 1)}"));
            for (int i = 0; i < 10; i++) soundCombobox.Items.Add(new ListItem($"{(i + 1) * 10}"));
            soundCombobox.SelectedIndex = 14;
            Manager.AudioManager.GlobalVolume = 0.5f;
            soundCombobox.SelectedIndexChanged += (sender, e) =>
            {
                Manager.AudioManager.GlobalVolume = float.Parse(soundCombobox.SelectedItem.Text) / 100;
                AudioManager.StopMusic();
                AudioManager.ChangeSong(ContentManager.UpbeatSong, true);
                AudioManager.PlayEffect(ContentManager.PhoneRingingSoundEffect);
            };

            Label soundLabel = new Label()
            {
                Text = "Volume",
                GridColumn = 0,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(24)),
                TextColor = Color.Black
            };
            grid.Widgets.Add(soundGrid);
            soundGrid.Widgets.Add(soundCombobox);
            soundGrid.Widgets.Add(soundLabel);

            CheckBox checkBox = new CheckBox()
            {
                Text = "Play Tutorial",
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(24)),
                IsChecked = true,
                GridColumn = 1,
                GridRow = 5,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                TextColor = Color.Black
            };
            grid.Widgets.Add(checkBox);

            TextButton button = new TextButton
            {
                Text = "Play",
                GridColumn = 1,
                GridRow = 7,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(24)),
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = (int)SizeManager.ScaleForWidth(JamGame.BaseWidth / 6),
                VerticalAlignment = VerticalAlignment.Stretch,
            };
            button.Click += (sender, e) => { AudioManager.StopMusic(); StateManager.ChangeTo<GameState>(GameState.Name, checkBox.IsChecked); };
            grid.Widgets.Add(button);

            TextButton quitButton = new TextButton
            {
                Text = "Exit",
                GridColumn = 1,
                GridRow = 8,
                Font = fontSystem.GetFont((int)SizeManager.ScaleForWidth(20)),
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = (int)SizeManager.ScaleForWidth(JamGame.BaseWidth / 8),
                VerticalAlignment = VerticalAlignment.Stretch,
            };
            quitButton.Click += (sender, e) => { JamGame.Exit(); };
            grid.Widgets.Add(quitButton);

            JamGame.Dekstop.Root = grid;
        }
    }
}
