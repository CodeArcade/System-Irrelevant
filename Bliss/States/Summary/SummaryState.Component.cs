using Bliss.States.Game;
using FontStashSharp;
using Microsoft.Xna.Framework;
using MonoGame.Extended.Content;
using Myra.Graphics2D.UI;

namespace Bliss.States.Summary
{
    public partial class SummaryState : State
    {
        FontSystem FontSystem { get; set; }

        protected override void LoadComponents()
        {
            FontSystem = new FontSystem();

            Grid grid = new Grid()
            {
                ColumnSpacing = 8,
                RowSpacing = 8
            };
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForWidth(JamGame.BaseWidth / 3)));
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Fill));
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForWidth(JamGame.BaseWidth / 3)));
            grid.RowsProportions.Add(new Proportion(ProportionType.Fill));

            Grid innerGrid = new Grid()
            {
                ColumnSpacing = 8,
                RowSpacing = 8,
                GridColumn = 1
            };

            innerGrid.ColumnsProportions.Add(new Proportion(ProportionType.Fill));

            // Spacer
            innerGrid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.3))));
            // Title
            innerGrid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Day
            innerGrid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Documents left
            innerGrid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Wrongly sorted documents
            innerGrid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Missed calls
            innerGrid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Wrongly ended
            innerGrid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Warnings
            innerGrid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Button
            innerGrid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.05))));
            // Spacer
            innerGrid.RowsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForHeight((int)(JamGame.BaseHeight * 0.3))));

            FontSystem.AddFont(JamGame.Content.OpenStream("Fonts/Arial.ttf"));

            Label title = new Label()
            {
                Text = "Day Summary",
                GridColumn = 0,
                GridRow = 1,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Font = FontSystem.GetFont((int)SizeManager.ScaleForWidth(32)),
                TextColor = Color.Black
            };

            innerGrid.Widgets.Add(GetStatGrid("Day:", PlayerStats.Day.ToString(), 2, Color.Black));
            innerGrid.Widgets.Add(GetStatGrid("Unsorted Documents:", PlayerStats.DocumentsLeft.ToString(), 3, PlayerStats.DocumentsLeft >= 3 ? Color.Red : Color.Black));
            innerGrid.Widgets.Add(GetStatGrid("Wrongly Sorted Documents:", PlayerStats.WronglySortedDocuments.ToString(), 4, PlayerStats.WronglySortedDocuments >= 3 ? Color.Red : Color.Black));
            innerGrid.Widgets.Add(GetStatGrid("Missed Calls:", PlayerStats.MissedCalls.ToString(), 5, PlayerStats.MissedCalls >= 1 ? Color.Red : Color.Black));
            innerGrid.Widgets.Add(GetStatGrid("Prematurely Ended Calls:", PlayerStats.WronglyEndedCalls.ToString(), 6, PlayerStats.WronglyEndedCalls >= 1 ? Color.Red : Color.Black));
            innerGrid.Widgets.Add(GetStatGrid("Warning Notices:", PlayerStats.Warnings.ToString(), 7,
                PlayerStats.Warnings == 0 ? Color.Green : PlayerStats.Warnings >= 1 && PlayerStats.Warnings < 3 ? Color.Yellow : Color.Red));

            TextButton button = new TextButton
            {
                Text = "Next Day",
                GridColumn = 0,
                GridRow = 8,
                Font = FontSystem.GetFont((int)SizeManager.ScaleForWidth(16)),
                HorizontalAlignment = HorizontalAlignment.Center,
                Width = (int)SizeManager.ScaleForWidth(JamGame.BaseWidth / 6),
                VerticalAlignment = VerticalAlignment.Stretch
            };
            button.Click += (sender, e) => { AudioManager.StopMusic(); StateManager.ChangeTo<GameState>(GameState.Name, PlayerStats, Rules); };

            innerGrid.Widgets.Add(title);
            innerGrid.Widgets.Add(button);
            grid.Widgets.Add(innerGrid);
            JamGame.Dekstop.Root = grid;
        }

        private Grid GetStatGrid(string text, string value, int row, Color foregroundColor)
        {
            Grid grid = new Grid()
            {
                ColumnSpacing = 8,
                RowSpacing = 8,
                GridColumn = 0,
                GridRow = row
            };
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Pixels, SizeManager.ScaleForWidth(JamGame.BaseWidth / 6)));
            grid.ColumnsProportions.Add(new Proportion(ProportionType.Fill));
            grid.RowsProportions.Add(new Proportion(ProportionType.Fill));

            Label textLabel = new Label()
            {
                Text = text,
                GridColumn = 0,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Center,
                Font = FontSystem.GetFont((int)SizeManager.ScaleForWidth(16)),
                TextColor = foregroundColor
            };

            Label valueLabel = new Label()
            {
                Text = value,
                GridColumn = 1,
                GridRow = 0,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                Font = FontSystem.GetFont((int)SizeManager.ScaleForWidth(16)),
                TextColor = foregroundColor,
                Padding = new Myra.Graphics2D.Thickness((int)SizeManager.ScaleForWidth(20), 0, 0, 0)
            };

            grid.Widgets.Add(textLabel);
            grid.Widgets.Add(valueLabel);

            return grid;
        }

    }
}
