using Bliss.Component.Sprites.Office.Documents;
using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Bliss.Models
{
    public class PlayerStats
    {
        public int Day { get; set; }

        public int MissedCalls { get; set; }
        public int WronglyEndedCalls { get; set; }

        public int WronglySortedDocuments { get; set; }

        public int TimesToManyDocuments { get; set; }

        public int Warnings { get; set; }
    }
}
