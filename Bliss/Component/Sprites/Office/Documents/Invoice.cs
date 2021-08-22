using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Bliss.Component.Sprites.Office.Documents
{
    public class Invoice : BaseDocument
    {
        public Invoice(Vector2 spawnPoint, Rectangle table) : base(spawnPoint, table)
        {
            Texture = ContentManager.InvoiceTexture;
            Size = SizeManager.GetSize(150, 200);
            
            Load(spawnPoint, table);
        }

        public override List<Component> GetDetailViewComponents()
        {
            throw new NotImplementedException();
        }
    }
}
