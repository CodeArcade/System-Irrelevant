using Bliss.Component.Sprites;
using Bliss.Component.Sprites.Office;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Bliss.States.Game
{
    public partial class GameState
    {
        protected Table Table { get; set; }
        protected Clock Clock { get; set; }
        protected Phone Phone { get; set; }
        protected List<Sprite> DocumentSpawnPoints { get; set; }
        protected List<DocumentOrganizer> DocumentOrganizers { get; set; }

        protected override void LoadComponents()
        {
            AddTable();
            AddClock();
            AddPhone();

            DocumentOrganizers = new List<DocumentOrganizer>();

            AddDocumentOrganizer(
                    ContentManager.DocumentOrganizerOneTexture,
                    Table.Rectangle.Width,
                    (int)(Table.Rectangle.Y * 1.2),
                    210,
                    160,
                    0
                );

            AddDocumentOrganizer(
                    ContentManager.DocumentOrganizerTwoTexture,
                    Table.Rectangle.Width,
                    (int)(Table.Rectangle.Y * 1.4 + SizeManager.ScaleForHeight(160)),
                    210,
                    160,
                    1
                );

            AddDocumentOrganizer(
                    ContentManager.DocumentOrganizerThreeTexture,
                  Table.Rectangle.Width,
                    (int)(Table.Rectangle.Y * 1.6 + SizeManager.ScaleForHeight(160) * 2),
                    210,
                    160,
                    2
                );

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
            Size size = SizeManager.GetSize(1000, 600);

            Table = new Table()
            {
                Size = size,
                Position = SizeManager.GetPosition(
                        (int)(SizeManager.ScaleForWidth(JamGame.BaseWidth) - size.Width) / 4,
                        (int)(SizeManager.ScaleForHeight(JamGame.BaseHeight) - size.Height) / 4
                    )
            };
            AddComponent(Table, States.Layers.Table);
        }

        private void AddClock()
        {
            Size clockSize = SizeManager.GetSize(125, 75);
            Clock = new Clock()
            {
                Size = clockSize,
                Position = new Vector2(
                        Table.Position.X + clockSize.Width / 2,
                        Table.Position.Y + clockSize.Width / 4
                    )
            };
            AddComponent(Clock, States.Layers.PlayingArea);
        }

        private void AddPhone()
        {
            Size size = SizeManager.GetSize(200, 125);
            Phone = new Phone()
            {
                Size = size,
                Position = new Vector2(
                        Table.Position.X + Clock.Size.Width / 8,
                        Table.Position.Y + size.Height
                    )
            };
            AddComponent(Phone, States.Layers.PlayingArea);
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

        private void AddDocumentOrganizer(Texture2D texture, int x, int y, int width, int height, int id)
        {
            DocumentOrganizer organizer = new DocumentOrganizer()
            {
                Size = SizeManager.GetSize(width, height),
                Position = new Vector2(x, y),
                Texture = texture,
                Id = id,
                CanBeClicked = false
            };
            organizer.OnClick += DocumentOrganizerClicked;

            DocumentOrganizers.Add(organizer);
            AddComponent(organizer, States.Layers.PlayingArea);
        }

    }
}
