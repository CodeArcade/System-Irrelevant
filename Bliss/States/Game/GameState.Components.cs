﻿using Bliss.Component.Office;
using Bliss.Component.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Bliss.States.Game
{
    public partial class GameState
    {
        protected Table Table { get; set; }
        protected List<Sprite> DocumentSpawnPoints { get; set; }

        protected override void LoadComponents()
        {
            AddTable();

            DocumentSpawnPoints = new List<Sprite>();
            // left side of desk
            AddDocumentSpawn(0, Table.Size.Height / 4);
            // left corner of desk
            AddDocumentSpawn(0, 0);
            // top middle of desk
            AddDocumentSpawn(Table.Size.Width / 4, 0);
            // right corner of desk
            AddDocumentSpawn(JamGame.BaseWidth, 0);
            // right side of desk
            AddDocumentSpawn(JamGame.BaseWidth, Table.Size.Height / 4);
        }

        private void AddTable()
        {
            Size tableSize = SizeManager.GetSize(1000, 600);

            Table = new Table()
            {
                Size = tableSize,
                Position = SizeManager.GetPosition(
                        (int)(SizeManager.ScaleForWidth(JamGame.BaseWidth) - tableSize.Width) / 4, 
                        (int)(SizeManager.ScaleForHeight(JamGame.BaseHeight) - tableSize.Height) / 4
                    )
            };
            AddComponent(Table, States.Layers.Table);
        }

        private void AddDocumentSpawn(int x, int y)
        {
            Sprite spawn = new Sprite()
            {
                Size = new Size(1, 1),
                Position = SizeManager.GetPosition(x, y),
                Texture = ContentManager.TableTexture
            };
            DocumentSpawnPoints.Add(spawn);
            AddComponent(spawn, States.Layers.Background);
        }

    }
}