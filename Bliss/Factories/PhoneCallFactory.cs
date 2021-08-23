using Bliss.Component.Sprites.Office;
using Bliss.Manager;
using Bliss.Models;
using System;
using System.Collections.Generic;
using Unity;

namespace Bliss.Factories
{
    public class PhoneCallFactory
    {
        [Dependency]
        public ContentManager ContentManager { get; set; }

        private static int MikeProgress { get; set; }

        public PhoneCall GetRandom()
        {
            return new Random().Next(0, 2) switch
            {
                0 => GetPrankCall(),
                1 => GetPrankCall(),
                _ => GetPrankCall(),
            };
        }

        public PhoneCall GetRandomImportant()
        {
            return new Random().Next(0, 1) switch
            {
                _ => GetPrankCall(),
            };
        }


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
                NewValidators = new Dictionary<OrganizerIds, List<System.Func<Component.Sprites.Office.Documents.BaseDocument, bool>>>()
                {
                    {
                        OrganizerIds.Bin,
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
                        Voice = ContentManager.DocumentSpawnedSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetMike()
        {
            MikeProgress++;

            return MikeProgress switch
            {
                1 => GetMike1(),
                2 => GetMike2(),
                _ => null,
            };
        }

        public PhoneCall GetMike1()
        {
            return null;
        }

        public PhoneCall GetMike2()
        {
            return null;
        }
    }
}
