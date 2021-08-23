using Bliss.Component.Sprites.Office.Documents;
using Bliss.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Bliss.Component.Sprites.Office
{
    public enum OrganizerIds
    {
        Green,
        Red,
        Blue,
        Bin
    }

    public class DocumentOrganizer : Clickable
    {
        public OrganizerIds Id { get; set; }
        public List<Func<BaseDocument, bool>> Validators { get; set; } = new List<Func<BaseDocument, bool>>();

        public bool Validate(BaseDocument document)
        {
            foreach (Func<BaseDocument, bool> validator in Validators)
            {
                if (!validator.Invoke(document)) return false;
            }

            return true;
        }
    }
}
