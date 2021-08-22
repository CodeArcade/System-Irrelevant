using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Bliss.Manager
{
    public class AudioManager
    {
        private Song CurrentSong;
        private Song NextSong;
        private bool Loop;
        private float Volume;

        public static float GlobalVolume { get; set; } = 1;

        public void PlayEffect(SoundEffect effect, float volume = 0, float pitch = 0) 
        {
            effect.Play(GlobalVolume + volume, pitch, 0);
        }

        public void Update()
        {
            ChangeSong();
        }

        private void ChangeSong()
        {
            if (NextSong is null) return;
            CurrentSong = NextSong;
            NextSong = null;

            MediaPlayer.IsRepeating = Loop;
            MediaPlayer.Stop();
            MediaPlayer.Volume = GlobalVolume + Volume;
            MediaPlayer.Play(CurrentSong);
        }

        public void Changesong(Song song, bool loop = false, float volume = 0)
        {
            NextSong = song;
            Loop = loop;
            Volume = volume;
        }

        public void StopMusic() => MediaPlayer.Stop();
    }
}
