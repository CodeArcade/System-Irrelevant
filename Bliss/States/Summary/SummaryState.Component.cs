using Bliss.Component.Sprites;
using Bliss.States.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.States.Summary
{
    public partial class SummaryState : State
    {
        protected override void LoadComponents()
        {
            Clickable button = new Clickable()
            {
                Position = SizeManager.GetPosition(500, 500),
                Size = SizeManager.GetSize(500, 500),
                Texture = ContentManager.BinTexture
            };
            button.OnClick += (sender, e) => { StateManager.ChangeTo<GameState>(GameState.Name, PlayerStats); };

            AddComponent(button, States.Layers.UI);
        }
    }
}
