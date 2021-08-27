using Bliss.Component.Sprites.Office;
using Bliss.Component.Sprites.Office.Documents;
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
        private static int BettyProgress { get; set; }
        private static int VladProgress { get; set; }
        private static int RuleProgress { get; set; }
        private Random Random { get; set; } = new Random();

        public PhoneCall GetRandom()
        {
            return Random.Next(0, 4) switch
            {
                0 => GetMisc(),
                1 => GetMike(),
                2 => GetVlad(),
                3 => GetBetty(),
                _ => GetPrankCall(),
            };
        }

        public PhoneCall GetMisc()
        {
            return Random.Next(0, 8) switch
            {
                0 => GetLibrary(),
                1 => GetBananas(),
                2 => GetTired(),
                3 => GetTimeTraveler(),
                4 => GetIcWiener(),
                5 => GetTrash(),
                6 => GetBigSmokes(),
                7 => GetDebbie(),
                _ => GetPrankCall(),
            };
        }

        public PhoneCall GetImportant()
        {
            RuleProgress++;

            return RuleProgress switch
            {
                1 => GetBossRacism(),
                2 => GetMikeRedChecks(),
                3 => GetBettyFuckMen(),
                4 => GetBettyLetters(),
                _ => GetPrankCall(),
            };
        }

        #region Misc

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
                        Text = "When I was in middle school",
                        Voice = ContentManager.Tired1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "our teachers told us that you can't 'make up' hours of sleep after not getting enough.",
                        Voice = ContentManager.Tired2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "And I thought that meant if I didn't get enough sleep one night",
                        Voice = ContentManager.Tired3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I would be tired for the rest of my life... And then I was.",
                        Voice = ContentManager.Tired4SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Remember to go to sleep kiddo.",
                        Voice = ContentManager.Tired5SoundEffect.CreateInstance()
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
                        Voice = ContentManager.Wiener1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "No? No one called I see wiener?",
                        Voice = ContentManager.Wiener2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You can't see a wiener? Well get some glasses then!",
                        Voice = ContentManager.Wiener3SoundEffect.CreateInstance()
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

        #endregion

        #region MikeStory

        public PhoneCall GetMike()
        {
            MikeProgress++;

            return MikeProgress switch
            {
                1 => GetMike1(),
                2 => GetMike2(),
                3 => GetMike3(),
                4 => GetMike4(),
                _ => GetMisc(),
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
                        Voice = ContentManager.MikeHotdog1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "The day that I quit was especially bad.",
                        Voice = ContentManager.MikeHotdog2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I spent 15 minutes trying to explain to an old man that we do not sell hot dogs - McDogs as he called them.",
                        Voice = ContentManager.MikeHotdog3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "And then he threatened to report me for 'withholding products from him'.",
                        Voice = ContentManager.MikeHotdog4SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Anyways, all I wanted to say is that I'm making hot dogs later, so if you want any, scoot on over. See ya later pal.",
                        Voice = ContentManager.MikeHotdog5SoundEffect.CreateInstance()
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
                        Voice = ContentManager.VladMike1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Is Mike bothering you?",
                        Voice = ContentManager.VladMike2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Don't worry, I got you.",
                        Voice = ContentManager.VladMike3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Don't say word.",
                        Voice = ContentManager.VladMike4SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I will make it stop. Do svidaniya.",
                        Voice = ContentManager.VladMike5SoundEffect.CreateInstance()
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

        #endregion

        #region VladStory

        public PhoneCall GetVlad()
        {
            VladProgress++;

            return VladProgress switch
            {
                0 => GetVladIntro(),
                1 => GetVladSalamanders(),
                2 => GetVladCarAlarms(),
                _ => GetMisc()
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
                        Voice = ContentManager.VladIntro1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You're phone working OK?",
                        Voice = ContentManager.VladIntro2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "If you get mail for vlad, just forward it to him.",
                        Voice = ContentManager.VladIntro3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Might be Uranium. XAXAXA! Ok, we talk later.",
                        Voice = ContentManager.VladIntro4SoundEffect.CreateInstance()
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
                        Voice = ContentManager.VladSalamandra1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You ever think about salamanders?",
                        Voice = ContentManager.VladSalamandra2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "The teenzy tiny crocodiles that don't hurt you?",
                        Voice = ContentManager.VladSalamandra3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Back home we call it salamandra.",
                        Voice = ContentManager.VladSalamandra4SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I like the name. it really fits. Anyway, do you need any? ",
                        Voice = ContentManager.VladSalamandra5SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I bought 20, but is too many. I will send you picture later.",
                        Voice = ContentManager.VladSalamandra6SoundEffect.CreateInstance()
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
                        Voice = ContentManager.VladCar1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Have you noticed that nobody hears car alarm and thinks 'Oh. Car is being stolen'.",
                        Voice = ContentManager.VladCar2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "They only think 'I hope car gets stolen faster, sound is annoying'.",
                        Voice = ContentManager.VladCar3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "So anyway... You need car?",
                        Voice = ContentManager.VladCar4SoundEffect.CreateInstance()
                    }
                }
            };
        }

        #endregion

        #region BettyStory

        public PhoneCall GetBetty()
        {
            BettyProgress++;
            return BettyProgress switch
            {
                1 => GetBettyIntro(),
                2 => GetBettyMystery(),
                _ => GetMisc()
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
                        Voice = ContentManager.BettyIntroduction1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Just checking in that you're still employed and well... alive.",
                        Voice = ContentManager.BettyIntroduction2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Teehee. Byebyee",
                        Voice = ContentManager.BettyIntroduction3SoundEffect.CreateInstance()
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
                        Voice = ContentManager.BettyMyster1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I came up with a fun one.",
                        Voice = ContentManager.BettyMyster2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "It's a reverse murder mystery called 'who the hell reanimated this person'?",
                        Voice = ContentManager.BettyMyster3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "All the players are assassins and they have to figure out who reanimated the person",
                        Voice = ContentManager.BettyMyster4SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "because that means there is someone out there who can get first-hand accounts of them.",
                        Voice = ContentManager.BettyMyster5SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Wanna come over and play? You can be the corpse if you want.",
                        Voice = ContentManager.BettyMyster6SoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetPentagrams()
        {
            return new PhoneCall()
            {
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hey, it's Betty!",
                        Voice = ContentManager.BettyPentagram1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I was bored yesterday and decided to draw a bunch of pentagrams on a contract.",
                        Voice = ContentManager.BettyPentagram2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I ended up with at least 100 of them, but before I could draw any more,",
                        Voice = ContentManager.BettyPentagram3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "a devilish-looking guy wearing a red suit broke down the door of the office and yelled",
                        Voice = ContentManager.BettyPentagram4SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "'WHAT THE HELL DO YOU WANT?!'",
                        Voice = ContentManager.BettyPentagram5SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Then he snatched the contract, somehow burned it without a lighter and ran away.",
                        Voice = ContentManager.BettyPentagram6SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I will never stop thinking about that man.",
                        Voice = ContentManager.BettyPentagram7SoundEffect.CreateInstance()
                    }
                }
            };
        }

        #endregion

        #region Rules

        public PhoneCall GetBettyFuckMen()
        {
            return new PhoneCall()
            {
                NewValidators = new Dictionary<OrganizerIds, List<Rule>>()
                {
                    {
                        OrganizerIds.Bin, new List<Rule>
                        {
                            new Rule(DocumentType.Application)
                            {
                                Validate = (document) => { if( document is Application application) { return application.Sex == Sexes.Male; }  return false; },
                                Description = "Toss all applications sent by men!"
                            } // TODO: previous validators ?
                        }
                    }
                },
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hey rookie! This is Betty. You know, from HR.",
                        Voice = ContentManager.BettyFuckMen1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Listen, I have some new rules for you.",
                        Voice = ContentManager.BettyFuckMen2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Now, we get lot's of applications. But we don't need that many, right?",
                        Voice = ContentManager.BettyFuckMen3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "So, until further notice, just toss all applications sent by men!",
                        Voice = ContentManager.BettyFuckMen4SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Don't worry, the Boss approved it. Alright, talk to you later!",
                        Voice = ContentManager.BettyFuckMen5SoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetBettyLetters()
        {
            return new PhoneCall()
            {
                NewValidators = new Dictionary<OrganizerIds, List<Rule>>()
                {
                    {
                        OrganizerIds.Bin, new List<Rule>
                        {
                            new Rule(DocumentType.Application)
                            {
                                Validate = (document) => { if( document is Application application) { return application.Sex == Sexes.Male; }  return false; },
                                Description = "Toss all applications sent by men!"
                            }
                        } 
                    }
                },
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hey sweetheart.",
                        Voice = ContentManager.BettyLetter1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "So, about 50 letters in the last week arrived without any stamps and return addresses",
                        Voice = ContentManager.BettyLetter2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "so we couldn't send them out",
                        Voice = ContentManager.BettyLetter3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "From now on, please make sure that every letter has a stamp and a return address on it.",
                        Voice = ContentManager.BettyLetter4SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Thanks dear!",
                        Voice = ContentManager.BettyLetter5SoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetBettyPayment()
        {
            return new PhoneCall()
            {
                NewValidators = new Dictionary<OrganizerIds, List<Rule>>()
                {
                    {
                        OrganizerIds.Bin, new List<Rule>
                        {
                            new Rule(DocumentType.Application)
                            {
                                Validate = (document) => { if( document is Application application) { return application.Sex == Sexes.Male; }  return false; },
                                Description = "Toss all applications sent by men!"
                            } 
                        }
                    }
                },
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "If I could I'd kill every single stupid braindead monkey from accounting.",
                        Voice = ContentManager.BettyPentagram1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "NONE OF THE CHECKS I RECEIVED TODAY hat a department listed on them.",
                        Voice = ContentManager.BettyPentagram2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "So from now on, when you get a paycheck",
                        Voice = ContentManager.BettyPentagram3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "please confirm that there is a department on it and that it is a valid one.",
                        Voice = ContentManager.BettyPentagram4SoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetMikeRedChecks()
        {
            return new PhoneCall()
            {
                NewValidators = new Dictionary<OrganizerIds, List<Rule>>()
                {
                    {
                        OrganizerIds.Red, new List<Rule>()
                        {
                            Rules.IsPaycheckForRed,
                            Rules.IsApplicationForRed
                        }
                    },
                    { 
                        OrganizerIds.Blue, 
                        new List<Rule>() 
                    }
                },
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hello, it's Mike!",
                        Voice = ContentManager.MikePaycheck1SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "For one reason or another I don't seem to be getting any paychecks.",
                        Voice = ContentManager.MikePaycheck2SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You're putting them in the red organizer, right?",
                        Voice = ContentManager.MikePaycheck3SoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Well if you don't, you better start doing it.",
                        Voice = ContentManager.MikePaycheck4SoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetBossTutorial()
        {
            return new PhoneCall()
            {
                NewValidators = new Dictionary<OrganizerIds, List<Rule>>()
                {
                    {
                        OrganizerIds.Blue, new List<Rule>()
                        {
                            Rules.IsContract,
                            Rules.IsPaycheckForBlue
                        }
                    },
                    {
                        OrganizerIds.Red, new List<Rule>()
                        {
                            Rules.IsApplicationForRed
                        }
                    },
                    {
                        OrganizerIds.Green, new List<Rule>()
                        {
                            Rules.IsLetter
                        }
                    },
                    {
                        OrganizerIds.Bin, new List<Rule>()
                        {
                            Rules.IsClassified
                        }
                    }
                },
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Hey there new guy, this is your boss speaking.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I thought I'd give you a quick rundown on how your job actually works.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "It's rather simple.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You get documents, you sort them. Done deal.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "First: this is a contract.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You can read them if you want, but for now put them in the blue organizer.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Next, this is a paycheck.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "It's just a regular paycheck.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "It's got a date, it's got the amount and the department.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "You can also toss them into the blue organizer.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "This is an application.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "It's from the people that will replace you one day.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Hahaha, just kidding. Just put them in the red organizer.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Now this is just a regular letter.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Nothing special about it. Put 'em in the green organizer.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Now this... this is classified.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Don't open it. Just throw it in the trash!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I mean, I can't stop you from opening it as you throw it away anyways...",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Well just don't!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Alright, that's about everything.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "If there are any new rules, people will call you to inform you about it.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "So don't hang up on them all willy nilly.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "And now go to work!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetBossRacism()
        {
            return new PhoneCall()
            {
                NewValidators = new Dictionary<OrganizerIds, List<Rule>>()
                {
                    {
                        OrganizerIds.Red, new List<Rule>()
                        {
                            Rules.AmericanApplicants
                        }
                    },
                    {
                        OrganizerIds.Bin, new List<Rule>()
                        {
                            Rules.HardcoreRacism
                        }
                    }
                },
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "New guy, are you working hard?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Well, I hope you do!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine() 
                    {
                        Text = "I know, I only told yo what to do earlier today,",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "but you gotta change things up a bit, right?",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Well, I'm calling about applications.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "I want you to toss all applications that are not from americans.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Got it? No foreigners!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        public PhoneCall GetBossLightRacism()
        {
            return new PhoneCall()
            {
                NewValidators = new Dictionary<OrganizerIds, List<Rule>>()
                {
                    {
                        OrganizerIds.Red, new List<Rule>()
                        {
                            Rules.FuckNorthernEurope
                        }
                    },
                    {
                        OrganizerIds.Bin, new List<Rule>()
                        {
                            Rules.LightcoreRacism
                        }
                    }
                },
                VoiceLines = new List<VoiceLine>()
                {
                    new VoiceLine()
                    {
                        Text = "Alright alright, I changed my mind.",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Foreigners aren't that bad. At least some of them!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "From now on, I only need you to toss applications",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "from poeple coming from the following countries:",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Denmark, Sweden, Norway, Finland and the UK",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "Also, you gotta make sure that they list an existing country!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    },
                    new VoiceLine()
                    {
                        Text = "No people from 'This-aint-real-istan'!",
                        Voice = ContentManager.SilenceSoundEffect.CreateInstance()
                    }
                }
            };
        }

        #endregion
    }
}
