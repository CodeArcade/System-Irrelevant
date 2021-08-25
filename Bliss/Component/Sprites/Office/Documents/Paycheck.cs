using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bliss.Component.Sprites.Office.Documents
{
    public class Paycheck : BaseDocument
    {
        public string Department { get; set; }
        public DateTime? Date { get; set; }

        public Paycheck(Vector2 spawnPoint, Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.PaycheckTexture;
            Size = SizeManager.GetSize(200, 100);

            Load(spawnPoint, tableArea);
        }

        public override List<Component> GetDetailViewComponents()
        {
            throw new NotImplementedException();
        }
    }
}
