using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using System;

namespace Bliss.Manager
{
    public class AudioManager
    {
        private Song CurrentSong;
        private Song NextSong;
        private bool Loop;
        private float Volume;

        public static float GlobalVolume { get; set; } = 1;

        public SoundEffectInstance PlayEffect(SoundEffect effect, float volume = 0, float pitch = 0, bool isLooped = false)
        {
            SoundEffectInstance soundEffectInstance = effect.CreateInstance();
            soundEffectInstance.Volume = Math.Max(GlobalVolume + volume, 0.01f);
            if (GlobalVolume == 0) soundEffectInstance.Volume = 0;

            soundEffectInstance.Pitch = pitch;
            soundEffectInstance.IsLooped = isLooped;

            soundEffectInstance.Play();

            return soundEffectInstance;
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

        public void ChangeSong(Song song, bool loop = false, float volume = 0)
        {
            NextSong = song;
            Loop = loop;
            Volume = volume;
        }

        public void StopMusic() => MediaPlayer.Stop();
    }
}
