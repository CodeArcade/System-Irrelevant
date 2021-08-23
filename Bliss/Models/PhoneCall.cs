using System.Collections.Generic;

namespace Bliss.Models
{
    public class PhoneCall
    {
        public bool IsImportant { get; set; }
        public List<VoiceLine> VoiceLines { get; set; }
    }
}
