using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Bliss.Component.Sprites.Office.Documents
{
    public class Application : BaseDocument
    {
        public DateTime Birthday { get; set; }
        public bool? Sex { get; set; }
        public string Address { get; set; }

        public Application(Vector2 spawnPoint, Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.ApplicationTexture;
            Size = SizeManager.GetSize(150, 200);

            Load(spawnPoint, tableArea);
        }

        public override List<Component> GetDetailViewComponents()
        {
            throw new NotImplementedException();
        }
    }
}
