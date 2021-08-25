using Bliss.Component.Sprites.Office.Documents;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Bliss.Models
{
    public class Rule
    {
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public Func<BaseDocument, bool> Validate { get; set; }
    }
}
