using System.Net.NetworkInformation;

namespace Bliss.Models
{
    public class PlayerStats
    {
        public int MissedCalls { get; set; }
        public int WronglyEndedCalls { get; set; }

        public int WronglyThrashedDocuments { get; set; }
        public int WronglySortedDocuments { get; set; }
        
        public int TimesToManyDocuments { get; set; }

        public int Warnings { get; set; }
    }
}
