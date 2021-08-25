using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Bliss.Component.Sprites.Office.Documents
{

    /// <summary>
    /// The only valid ones are HR, PR, R&D, IT and accounting
    /// </summary>
    public enum Departments
    {
        HumanResources,
        PublicRelations,
        ResearchDevelopment,
        IT,
        Accounting,
        Design,
        Marketing,
        Purchasing,
        Export,
        Logistics
    }

    public class Paycheck : BaseDocument
    {
        public Departments Department { get; set; }
        public DateTime? Date { get; set; }

        public Paycheck(Vector2 spawnPoint, Microsoft.Xna.Framework.Rectangle tableArea) : base(spawnPoint, tableArea)
        {
            Texture = ContentManager.PaycheckTexture;
            Size = SizeManager.GetSize(200, 100);

            Load(spawnPoint, tableArea);
        }

        public override List<Component> GetDetailViewComponents()
        {
            Size size = SizeManager.GetSize(600, 300);

            Sprite sprite = new Sprite()
            {
                Size = size,
                Position = new Vector2(
                        (int)(SizeManager.ScaleForWidth(SizeManager.JamGame.BaseWidth) - size.Width) / 2,
                        (int)(SizeManager.ScaleForHeight(SizeManager.JamGame.BaseHeight) - size.Height) / 2
                    ),
                Texture = ContentManager.PaycheckTexture
            };

            return new List<Component>() { sprite };
        }
    }
}
