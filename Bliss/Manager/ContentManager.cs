using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
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

        public SoundEffect DocumentLandedSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/DocumentLanded");
        public SoundEffect DocumentSpawnedSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/DocumentSpawned");
        public SoundEffect DocumentPickedUpSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/DocumentPickedUp");
        public SoundEffect DocumentPutDownSoundEffect => JamGame.Content.Load<SoundEffect>("Sounds/DocumentPutDown");

        public SpriteFont ArialSpriteFont => JamGame.Content.Load<SpriteFont>("Fonts/Arial");
    }
}
