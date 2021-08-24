using Bliss.Component.Sprites;
using Bliss.States.Game;
using Myra.Graphics2D.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.States.Summary
{
    public partial class SummaryState : State
    {
        protected override void LoadComponents()
        {
            Grid grid = new Grid()
            {
                ShowGridLines = true,
                ColumnSpacing = 8,
                RowSpacing = 8
            };
            grid.ColumnsProportions.Add(new Proportion());
            grid.RowsProportions.Add(new Proportion());

            TextButton button = new TextButton
            {
                Text = "Next Day"
            };
            button.Click += (sender, e) => { StateManager.ChangeTo<GameState>(GameState.Name, PlayerStats); };

            grid.Widgets.Add(button);
            JamGame.Dekstop.Root = grid;
        }
    }
}
