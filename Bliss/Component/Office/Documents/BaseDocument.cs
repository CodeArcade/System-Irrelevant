using Bliss.Component.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace Bliss.Component.Office.Documents
{
    public abstract class BaseDocument : Sprite
    {
        private Vector2 SpawnPoint { get; set; }
        private float DistanceToTravel { get; set; }
        public bool DidLand { get; set; }

        public BaseDocument(Vector2 spawnPoint, Rectangle tableArea) { }

        /// <summary>
        /// Is not in constructor, because it has to be called after size has been set.
        /// </summary>
        /// <param name="spawnPoint"></param>
        /// <param name="tableArea"></param>
        protected void Load(Vector2 spawnPoint, Rectangle tableArea)
        {
            Random random = new Random();

            SpawnPoint = spawnPoint;
            Position = spawnPoint;

            // pick random position on table - reduce current size so document fits fully 
            Vector2 targetDestination = new Vector2(
                random.Next(tableArea.X + Size.Width, tableArea.Width - Size.Width),
                random.Next(tableArea.Y, tableArea.Height - Size.Height)
                );

            Speed = 3000;
            DistanceToTravel = DistanceTo(targetDestination);
            Direction = DirectionTo(targetDestination);
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Play  paper sound when reached destination

            // We are moving only a distance instead to the point, cause of the speed the exact point may be missed
            if (DistanceToTravel < DistanceTo(SpawnPoint))
            {
                if (!DidLand) AudioManager.PlayEffect(ContentManager.DocumentLandedSoundEffect);

                DidLand = true;
                return;
            }

            Position += Direction * Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            base.Update(gameTime);
        }

        /// <summary>
        /// This functions returns the components for the detail view of the document
        /// </summary>
        public abstract List<Component> GetDetailViewComponents();
    }
}
