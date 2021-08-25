using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Bliss.Component.Sprites.Office.Documents
{
    public class Letter : BaseDocument
    {
        public bool HasStamp { get; set; }
        public string ReturnAdress { get; set; }
        public string Department { get; set; }

        public Letter(Vector2 spawnPoint, Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.LetterTexture;
            Size = SizeManager.GetSize(200, 100);
            Load(spawnPoint, tableArea);
        }

        public override List<Component> GetDetailViewComponents()
        {
            throw new NotImplementedException();
        }
    }
}
