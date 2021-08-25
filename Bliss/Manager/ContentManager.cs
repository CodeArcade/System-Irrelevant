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

        public SpriteFont ArialSpriteFont => JamGame.Content.Load<SpriteFont>("Fonts/Arial");

        public Song CalmSong => JamGame.Content.Load<Song>("Music/Calm");
        public Song UpbeatSong => JamGame.Content.Load<Song>("Music/Upbeat");
    }
}
