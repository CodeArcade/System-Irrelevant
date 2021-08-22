using Bliss.Component.Sprites.Office.Documents;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Bliss.States.Game
{
    public partial class GameState : State
    {
        public static string Name = "Game";

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space)) SpawnDocument();

            base.Update(gameTime);
        }

        private void SpawnDocument()
        {
            AudioManager.PlayEffect(ContentManager.DocumentSpawnedSoundEffect);
            Random random = new Random();
            AddComponent(new Invoice(DocumentSpawnPoints[random.Next(0, DocumentSpawnPoints.Count)].Position, Table.Rectangle), States.Layers.PlayingArea);
        }

    }
}