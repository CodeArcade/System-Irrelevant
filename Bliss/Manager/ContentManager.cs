using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using MonoGame.Extended.Content;
using Unity;

namespace Bliss.Manager
{
    public class ContentManager
    {
        [Dependency]
        public JamGame JamGame { get; set; }
        
        public Texture2D TableTexture => JamGame.Content.Load<Texture2D>("Sprites/Table");
        public Texture2D ContractTexture => JamGame.Content.Load<Texture2D>("Sprites/Contract");
        public Texture2D ApplicationTexture => JamGame.Content.Load<Texture2D>("Sprites/Application");
        public Texture2D ClassifiedTexture => JamGame.Content.Load<Texture2D>("Sprites/Classified");
        public Texture2D LetterTexture => JamGame.Content.Load<Texture2D>("Sprites/Letter");
        public Texture2D PaycheckTexture => JamGame.Content.Load<Texture2D>("Sprites/Paycheck");
        public Texture2D ClockTexture => JamGame.Content.Load<Texture2D>("Sprites/Clock");

        public Texture2D DocumentOrganizerOneTexture => JamGame.Content.Load<Texture2D>("Sprites/DocumentOrganizerOne");
        public Texture2D DocumentOrganizerTwoTexture => JamGame.Content.Load<Texture2D>("Sprites/DocumentOrganizerTwo");
        public Texture2D DocumentOrganizerThreeTexture => JamGame.Content.Load<Texture2D>("Sprites/DocumentOrganizerThree");
        public Texture2D BinTexture => JamGame.Content.Load<Texture2D>("Sprites/Bin");

        public Texture2D ClockZeroTexture => JamGame.Content.Load<Texture2D>("Sprites/0");
        public Texture2D ClockOneTexture => JamGame.Content.Load<Texture2D>("Sprites/1");
        public Texture2D ClockTwoTexture => JamGame.Content.Load<Texture2D>("Sprites/2");
        public Texture2D ClockThreeTexture => JamGame.Content.Load<Texture2D>("Sprites/3");
        public Texture2D ClockFourTexture => JamGame.Content.Load<Texture2D>("Sprites/4");
        public Texture2D ClockFiveTexture => JamGame.Content.Load<Texture2D>("Sprites/5");
        public Texture2D ClockSixTexture => JamGame.Content.Load<Texture2D>("Sprites/6");
        public Texture2D ClockSevenTexture => JamGame.Content.Load<Texture2D>("Sprites/7");
        public Texture2D ClockEightTexture => JamGame.Content.Load<Texture2D>("Sprites/8");
        public Texture2D ClockNineTexture => JamGame.Content.Load<Texture2D>("Sprites/9");
        public Texture2D ClockColonTexture => JamGame.Content.Load<Texture2D>("Sprites/Colon");

        public Texture2D StickyNoteTexture => JamGame.Content.Load<Texture2D>("Sprites/StickyNote");

        public Texture2D PhoneIdleAnimation => JamGame.Content.Load<Texture2D>("Animations/PhoneIdle");
        public Texture2D PhoneRingingAnimation => JamGame.Content.Load<Texture2D>("Animations/PhoneRinging");
        public Texture2D PhonePickedUpAnimation => JamGame.Content.Load<Texture2D>("Animations/PhonePickedUp");
        public Texture2D PhoneTexture => JamGame.Content.Load<Texture2D>("Sprites/Phone");

        public Texture2D TextboxTexture => JamGame.Content.Load<Texture2D>("Sprites/Textbox");
        public Texture2D TextboxAdvanceTexture => JamGame.Content.Load<Texture2D>("Sprites/TextAdvance");

        public SoundEffect DocumentLandedSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/DocumentLanded");
        public SoundEffect DocumentSpawnedSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/DocumentSpawned");
        public SoundEffect DocumentPickedUpSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/DocumentPickedUp");
        public SoundEffect DocumentPutDownSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/DocumentPutDown");
        public SoundEffect DocumentThrasedSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/DocumentThrased");

        public SoundEffect NewRuleSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/NewRule");

        public SoundEffect SilenceSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/Silence");

        public SoundEffect PhoneRingingSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/PhoneRinging");
        public SoundEffect PhoneHangUpSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/PhoneHangUp");
        public SoundEffect PhonePickUpSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/PhonePickUp");
        public SoundEffect PhoneCallOverSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/PhoneCallOver");

        public SoundEffect MikeDinner1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Dinner/Mike1");
        public SoundEffect MikeDinner2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Dinner/Mike2");
        public SoundEffect MikeDinner3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Dinner/Mike3");
        public SoundEffect MikeDinner4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Dinner/Mike4");

        public SoundEffect MikeHotdog1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Hotdog/Mike1");
        public SoundEffect MikeHotdog2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Hotdog/Mike2");
        public SoundEffect MikeHotdog3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Hotdog/Mike3");
        public SoundEffect MikeHotdog4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Hotdog/Mike4");
        public SoundEffect MikeHotdog5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Hotdog/Mike5");

        public SoundEffect MikePaycheck1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Paycheck/Mike1");
        public SoundEffect MikePaycheck2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Paycheck/Mike2");
        public SoundEffect MikePaycheck3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Paycheck/Mike3");
        public SoundEffect MikePaycheck4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Paycheck/Mike4");

        public SoundEffect MikeContract1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Contract/Mike1");
        public SoundEffect MikeContract2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Contract/Mike2");
        public SoundEffect MikeContract3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Contract/Mike3");
        public SoundEffect MikeContract4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Contract/Mike4");

        public SoundEffect BettyFuckMen1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/FuckMen/Betty1");
        public SoundEffect BettyFuckMen2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/FuckMen/Betty2");
        public SoundEffect BettyFuckMen3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/FuckMen/Betty3");
        public SoundEffect BettyFuckMen4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/FuckMen/Betty4");
        public SoundEffect BettyFuckMen5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/FuckMen/Betty5");

        public SoundEffect BettyIntroduction1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Introduction/Betty1");
        public SoundEffect BettyIntroduction2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Introduction/Betty2");
        public SoundEffect BettyIntroduction3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Introduction/Betty3");

        public SoundEffect BettyLetter1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Letter/Betty1");
        public SoundEffect BettyLetter2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Letter/Betty2");
        public SoundEffect BettyLetter3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Letter/Betty3");
        public SoundEffect BettyLetter4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Letter/Betty4");
        public SoundEffect BettyLetter5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Letter/Betty5");

        public SoundEffect BettyMyster1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Mystery/Betty1");
        public SoundEffect BettyMyster2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Mystery/Betty2");
        public SoundEffect BettyMyster3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Mystery/Betty3");
        public SoundEffect BettyMyster4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Mystery/Betty4");
        public SoundEffect BettyMyster5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Mystery/Betty5");
        public SoundEffect BettyMyster6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Mystery/Betty6");

        public SoundEffect BettyPaycheck1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Paycheck/Betty1");
        public SoundEffect BettyPaycheck2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Paycheck/Betty2");
        public SoundEffect BettyPaycheck3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Paycheck/Betty3");
        public SoundEffect BettyPaycheck4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Paycheck/Betty4");

        public SoundEffect BettyPentagram1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Pentagrams/Betty1");
        public SoundEffect BettyPentagram2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Pentagrams/Betty2");
        public SoundEffect BettyPentagram3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Pentagrams/Betty3");
        public SoundEffect BettyPentagram4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Pentagrams/Betty4");
        public SoundEffect BettyPentagram5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Pentagrams/Betty5");
        public SoundEffect BettyPentagram6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Pentagrams/Betty6");
        public SoundEffect BettyPentagram7SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Betty/Pentagrams/Betty7");

        public SoundEffect Tired1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Tired/Tired1");
        public SoundEffect Tired2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Tired/Tired2");
        public SoundEffect Tired3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Tired/Tired3");
        public SoundEffect Tired4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Tired/Tired4");
        public SoundEffect Tired5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Tired/Tired5");

        public SoundEffect Wiener1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Wiener/Winer1");
        public SoundEffect Wiener2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Wiener/Winer2");
        public SoundEffect Wiener3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Wiener/Winer3");

        public SoundEffect VladCar1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Car/Vlad1");
        public SoundEffect VladCar2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Car/Vlad2");
        public SoundEffect VladCar3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Car/Vlad3");
        public SoundEffect VladCar4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Car/Vlad4");

        public SoundEffect VladIntro1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Intro/Vlad1");
        public SoundEffect VladIntro2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Intro/Vlad2");
        public SoundEffect VladIntro3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Intro/Vlad3");
        public SoundEffect VladIntro4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Intro/Vlad4");

        public SoundEffect VladMike1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Mike/Vlad1");
        public SoundEffect VladMike2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Mike/Vlad2");
        public SoundEffect VladMike3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Mike/Vlad3");
        public SoundEffect VladMike4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Mike/Vlad4");
        public SoundEffect VladMike5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Mike/Vlad5");
        public SoundEffect VladMike6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Mike/Vlad6");

        public SoundEffect VladSalamandra1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Salamandra/Vlad1");
        public SoundEffect VladSalamandra2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Salamandra/Vlad2");
        public SoundEffect VladSalamandra3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Salamandra/Vlad3");
        public SoundEffect VladSalamandra4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Salamandra/Vlad4");
        public SoundEffect VladSalamandra5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Salamandra/Vlad5");
        public SoundEffect VladSalamandra6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Vlad/Salamandra/Vlad6");

        public SoundEffect BossIntro1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss1");
        public SoundEffect BossIntro2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss2");
        public SoundEffect BossIntro3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss3");
        public SoundEffect BossIntro4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss4");
        public SoundEffect BossIntro5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss5");
        public SoundEffect BossIntro6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss6");
        public SoundEffect BossIntro7SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss7");
        public SoundEffect BossIntro8SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss8");
        public SoundEffect BossIntro9SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss9");
        public SoundEffect BossIntro10SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss10");
        public SoundEffect BossIntro11SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss11");
        public SoundEffect BossIntro12SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss12");
        public SoundEffect BossIntro13SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss13");
        public SoundEffect BossIntro14SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss14");
        public SoundEffect BossIntro15SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss15");
        public SoundEffect BossIntro16SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss16");
        public SoundEffect BossIntro17SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss17");
        public SoundEffect BossIntro18SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss18");
        public SoundEffect BossIntro19SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss19");
        public SoundEffect BossIntro20SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss20");
        public SoundEffect BossIntro21SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss21");
        public SoundEffect BossIntro22SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss22");
        public SoundEffect BossIntro23SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Intro/Boss23");

        public SoundEffect BossHardcoreRacism1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Hardcore Racism/Boss1");
        public SoundEffect BossHardcoreRacism2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Hardcore Racism/Boss2");
        public SoundEffect BossHardcoreRacism3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Hardcore Racism/Boss3");
        public SoundEffect BossHardcoreRacism4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Hardcore Racism/Boss4");
        public SoundEffect BossHardcoreRacism5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Hardcore Racism/Boss5");
        public SoundEffect BossHardcoreRacism6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Hardcore Racism/Boss6");
        public SoundEffect BossHardcoreRacism7SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Hardcore Racism/Boss7");

        public SoundEffect BossLightcoreRacism1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Lightcore Racism/Boss1");
        public SoundEffect BossLightcoreRacism2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Lightcore Racism/Boss2");
        public SoundEffect BossLightcoreRacism3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Lightcore Racism/Boss3");
        public SoundEffect BossLightcoreRacism4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Lightcore Racism/Boss4");
        public SoundEffect BossLightcoreRacism5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Lightcore Racism/Boss5");
        public SoundEffect BossLightcoreRacism6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Lightcore Racism/Boss6");
        public SoundEffect BossLightcoreRacism7SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Lightcore Racism/Boss7");

        public SoundEffect BossMike1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Mike/Boss1");
        public SoundEffect BossMike2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Mike/Boss2");
        public SoundEffect BossMike3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Mike/Boss3");
        public SoundEffect BossMike4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Mike/Boss4");

        public SoundEffect BossOutro1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Outro/Boss1");
        public SoundEffect BossOutro2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Outro/Boss2");
        public SoundEffect BossOutro3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Outro/Boss3");
        public SoundEffect BossOutro4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Boss/Outro/Boss4");

        public SoundEffect Banana1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Banana/Banana1");
        public SoundEffect Banana2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Banana/Banana2");
        public SoundEffect Banana3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Banana/Banana3");
        public SoundEffect Banana4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Banana/Banana4");
        public SoundEffect Banana5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Banana/Banana5");
        public SoundEffect Banana6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Banana/Banana6");
        public SoundEffect Banana7SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Banana/Banana7");

        public SoundEffect BigSmokes1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/BigSmoke/BigSmokes1");
        public SoundEffect BigSmokes2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/BigSmoke/BigSmokes2");
        public SoundEffect BigSmokes3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/BigSmoke/BigSmokes3");
        public SoundEffect BigSmokes4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/BigSmoke/BigSmokes4");
        public SoundEffect BigSmokes5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/BigSmoke/BigSmokes5");
        public SoundEffect BigSmokes6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/BigSmoke/BigSmokes6");

        public SoundEffect Irigatex1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Irigatex/Irigatex1");
        public SoundEffect Irigatex2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Irigatex/Irigatex2");
        public SoundEffect Irigatex3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Irigatex/Irigatex3");
        public SoundEffect Irigatex4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Irigatex/Irigatex4");
        public SoundEffect Irigatex5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Irigatex/Irigatex5");
        public SoundEffect Irigatex6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Irigatex/Irigatex6");

        public SoundEffect Library1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Library/Library1");
        public SoundEffect Library2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Library/Library2");
        public SoundEffect Library3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Library/Library3");
        public SoundEffect Library4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Library/Library4");

        public SoundEffect MyMom1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/MyMom/Mom1");
        public SoundEffect MyMom2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/MyMom/Mom2");

        public SoundEffect TimeTraveler1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/TimeTraveler/TimeTraveler1");
        public SoundEffect TimeTraveler2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/TimeTraveler/TimeTraveler2");
        public SoundEffect TimeTraveler3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/TimeTraveler/TimeTraveler3");
        public SoundEffect TimeTraveler4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/TimeTraveler/TimeTraveler4");
        public SoundEffect TimeTraveler5SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/TimeTraveler/TimeTraveler5");
        public SoundEffect TimeTraveler6SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/TimeTraveler/TimeTraveler6");
        public SoundEffect TimeTraveler7SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/TimeTraveler/TimeTraveler7");
        public SoundEffect TimeTraveler8SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/TimeTraveler/TimeTraveler8");

        public SpriteFont ArialSpriteFont => JamGame.Content.Load<SpriteFont>("Fonts/Arial");

        public Song CalmSong => JamGame.Content.Load<Song>("Music/Calm");
        public Song UpbeatSong => JamGame.Content.Load<Song>("Music/Upbeat");
    }
}
