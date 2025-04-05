using Microsoft.Xna.Framework.Audio;
using Sprint_2.Interfaces;

namespace Sprint_2.Sound
{
    public class SoundEffectWrapper : ISound
    {
        private SoundEffect soundEffect;

        public SoundEffectWrapper(SoundEffect soundEffect)
        {
            this.soundEffect = soundEffect;
        }

        public void Play()
        {
            soundEffect.CreateInstance().Play(); // Always creates a new instance
        }

        public SoundEffectInstance CreateInstance()
        {
            return soundEffect.CreateInstance();
        }

        public void SetVolume(float volume)
        {
        }
    }
}
