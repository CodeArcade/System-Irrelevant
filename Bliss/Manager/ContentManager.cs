using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Content;
using Unity;

namespace Bliss.Manager
{
    public class ContentManager
    {
        [Dependency]
        public JamGame JamGame { get; set; }
        
        public Texture2D TableTexture => JamGame.Content.Load<Texture2D>("Sprites/Table");
        public Texture2D InvoiceTexture => JamGame.Content.Load<Texture2D>("Sprites/Invoice");
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

        public SoundEffect SilenceSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/Silence");

        public SoundEffect PhoneRingingSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/PhoneRinging");
        public SoundEffect PhoneHangUpSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/PhoneHangUp");
        public SoundEffect PhonePickUpSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/PhonePickUp");
        public SoundEffect PhoneCallOverSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/PhoneCallOver");

        public SoundEffect MikeDinner1SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Dinner/Mike1");
        public SoundEffect MikeDinner2SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Dinner/Mike2");
        public SoundEffect MikeDinner3SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Dinner/Mike3");
        public SoundEffect MikeDinner4SoundEffect => JamGame.Content.Load<SoundEffect>("VoiceLines/Mike/Dinner/Mike4");

        public SpriteFont ArialSpriteFont => JamGame.Content.Load<SpriteFont>("Fonts/Arial");
    }
}
