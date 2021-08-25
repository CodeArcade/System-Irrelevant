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

        private Random Random { get; set; } = new Random();

        public BaseDocument GetRandomDocument(Vector2 spawnPoint, Rectangle table)
        {
            return Random.Next(0, 5) switch
            {
                0 => GetContract(spawnPoint, table),
                1 => GetPaycheck(spawnPoint, table),
                2 => GetApplication(spawnPoint, table),
                3 => GetLetter(spawnPoint, table),
                4 => GetClassified(spawnPoint, table),
                _ => GetContract(spawnPoint, table)
                
            };
        }

        public Contract GetContract(Vector2 spawnPoint, Rectangle table)
        {
            return new Contract(spawnPoint, table);
        }

        public Paycheck GetPaycheck(Vector2 spawnPoint, Rectangle table)
        {
            return new Paycheck(spawnPoint, table);
        }

        public Application GetApplication(Vector2 spawnPoint, Rectangle table)
        {
            return new Application(spawnPoint, table);
        }

        public Letter GetLetter(Vector2 spawnPoint, Rectangle table)
        {
            return new Letter(spawnPoint, table);
        }

        public Classified GetClassified(Vector2 spawnPoint, Rectangle table)
        {
            return new Classified(spawnPoint, table);
        }
    }
}
