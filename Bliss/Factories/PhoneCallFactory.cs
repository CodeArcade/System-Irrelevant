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
        private static int RuleProgress { get; set; }
        private Random Random { get; set; } = new Random();

        public PhoneCall GetRandom()
        {
            return Random.Next(0, 13) switch
            {
                0 => GetPrankCall(),
                1 => GetLibrary(),
                2 => GetBananas(),
                3 => GetTired(),
                4 => GetTimeTraveler(),
                5 => GetIcWiener(),
                6 => GetTrash(),
                7 => GetBigSmokes(),
                8 => GetDebbie(),
                9 => GetMike(),
                10 => GetVladIntro(),
                11 => GetVladSalamanders(),
                12 => GetVladCarAlarms(),
                _ => GetPrankCall(),
            };
        }

        public PhoneCall GetImportant()
        {
            RuleProgress++;

            return RuleProgress switch
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
                NewValidators = new Dictionary<OrganizerIds, List<Rule>>()
                {
                    {
                        OrganizerIds.Bin,
                        new List<Rule>()
                            {
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

        public PhoneCall GetOutro()
        {
            return new PhoneCall()
            {
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

        public PhoneCall GetLibrary()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Did you know?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "The local library doesn't have a maximum book checkout limit and I am about to make them regret this.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You need anything?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetBananas()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "OH MY GOD!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Apparently artificial banana flavoring is based on the gros michel banana, which was wiped out by a banana plague in the 50s.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "The banana we eat today is a completely different thing calld 'The cavendish' and thats why banana candy doesn't taste like bananas.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "DO YOU KNOW how lied to I feel?!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Like, there was a BANANA APOCALYPSE and no one told me about it until now.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetTired()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "When I was in middle school, our teachers told us that you can't 'make up' hours of sleep after not getting enough.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "And I thought that meant if I didn't get enough sleep one night I would be tired for the rest of my life... And then I was.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Remember to go to sleep kiddo.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetTimeTraveler()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "I had a dream I was able to time travel and went like 10 million years into the future, but the INSTANT I went to the year 4000 I got stuck in a time dilation jail set up by the american government in the year 3877.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Everyone who tried to time travel back or forth across May 23, 3877 while on Earth would end up stuck in this time dilation chamber trap to stop time travelers.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "But like, it was so crazy and mismanaged because it was legit capturing like every single time traveler ever and the place had only been open for 12 minutes and was already getting overpopulated with nonstop multople recursive instances of this one guy trying to break previous versions of himself out of this time traveler jail.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Crazy times, I tell ya!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                }
            };
        }

        public PhoneCall GetIcWiener()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hi, I'm calling to talk to a Mr. Wiener, first name initials 'I.C.'?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "No? Nobody called I see wiener?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You can't see a wiener? Well get some glasses then!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetTrash()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Is this Irigatex corporation?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You guys were supposed to come and get my trash 4 days ago!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Do you have any idea how much hecking trash is lying around here?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "It smells like a dump. But this ain't a dump.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "My house is not where my trash belongs.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "So you better get your guys movin', I'm drowing in garbage!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetBigSmokes()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Yeah is that McBurgerBies?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I'll have 2 number 9s.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "A number 9 large.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "A number 6 with extra dip.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "A number 7.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Two number 45s, one with cheese and a large soda.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                }
            };
        }

        public PhoneCall GetDebbie()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hello, this is Deborah from ACME Inc.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I'm calling to inform you about our new mobile data plan!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "It's just $44.95 a week and offers up to 20 free minutes and 10 texts.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "To buy, please call >>555-ACMEPHONE<<. That's >>555-ACMEPHONE<<<.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
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
                3 => GetMike3(),
                4 => GetMike4(),
                _ => null,
            };
        }

        public PhoneCall GetMike1()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hey, it's Mike from accounting. Do you have any plans for lunch?",
                        Voice = ContentManager.MikeDinner1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I was thinking that maybe we could check out that new italian place.",
                        Voice = ContentManager.MikeDinner2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "What was it called again? Tony's? Little John's? I can't remember.",
                        Voice = ContentManager.MikeDinner3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Anyways, if you wanna join me, just come over to my desk. See ya later!",
                        Voice = ContentManager.MikeDinner4SoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetMike2()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hey, it's Mike from accounting. Before I worked here I had a pretty bad fast food job.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "The day that I quit was especially bad.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I spent 15 minutes trying to explain to an old man that we do not sell hot dogs and then he threatened to report me for 'withholding products from him'.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Anyways, all I wanted to say is that I'm making hot dogs later, so if you want any, scoot on over. See ya later pal.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetMike3()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hello. Vlad from IT. Everything alright?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Is Mike bothering you?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Don't worry, I got you.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Don't say word.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I will make it stop. Do svidaniya.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                }
            };
        }

        public PhoneCall GetMike4()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hey, new guy! Have you seen Mike around?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You know, Mike from Accounting.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "He skipped 3 days of work already and I think I'll have to fire him...",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetVladIntro()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hello. Vlad from IT here.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You're phone working OK?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "If you get mail for vlad, just forward it to him.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Might be Uranium. XAXAXA! Ok, we talk later.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetVladSalamanders()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hello. Its Vlad. From IT.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You ever think about salamanders?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "The teenzy tiny crocodiles that don't hurt you?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Back home we call it salamandra.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I like the name. it really fits. Anyway, do you need any? ",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I bought 20, but is too many. I will send you picture later.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetVladCarAlarms()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hello. It is Vlad talking.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Have you noticed that nobody hears car alarm and thinks 'Oh. Car is being stolen'.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "They only think 'I hope car gets stolen faster, sound is annoying'.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "So anyway... You need car?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetBettyIntro()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hey, Betty from HR!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "ust checking in that you're still employed and well... alive.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Teehee. Byebyee",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetBettyMystery()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hey, Betty here. Say, do you like party games?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Hey, Betty here. Say, do you like party games?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }
    }
}
