using Bliss.Component.Sprites;
using Bliss.Component.Sprites.Office.Documents;
using Bliss.Manager;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Bliss.Factories
{
    public class DocumentFactory
    {
        [Dependency]
        public SizeManager SizeManager { get; set; }

        public BaseDocument GetRandomDocument(Vector2 spawnPoint, Rectangle table)
        {
            return GetContract(spawnPoint, table);
        }

        public Contract GetContract(Vector2 spawnPoint, Rectangle table)
        {
           return new Contract(spawnPoint, table)
            {
                Size = SizeManager.GetSize(150, 200)
            };
        }
    }
}
