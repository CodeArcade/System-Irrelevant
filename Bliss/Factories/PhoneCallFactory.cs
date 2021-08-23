using Bliss.Component.Sprites.Office;
using Bliss.Manager;
using Bliss.Models;
using System.Collections.Generic;
using Unity;

namespace Bliss.Factories
{
    public class PhoneCallFactory
    {
        [Dependency]
        public ContentManager ContentManager { get; set; }

        public PhoneCall GetPrankCall()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "...",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetIntro()
        {
            return new PhoneCall()
            {
                NewValidators = new Dictionary<int, List<System.Func<Component.Sprites.Office.Documents.BaseDocument, bool>>>()
                {
                    { 
                        (int)OrganizerIds.Bin, 
                        new List<System.Func<Component.Sprites.Office.Documents.BaseDocument, bool>>() 
                            {
                                (document) => { return false; }
                            } 
                    }
                },
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "...",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }
    }
}
