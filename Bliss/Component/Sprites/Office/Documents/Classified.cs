using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Component.Sprites.Office.Documents
{
    public class Classified : BaseDocument
    {
        public Classified(Vector2 spawnPoint, Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.ClassifiedTexture;
            Size = SizeManager.GetSize(150, 150);

            Load(spawnPoint, tableArea);
        }

        public override List<Component> GetDetailViewComponents()
        {
            throw new NotImplementedException();
        }
    }
}
