using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Sprint_2.Interfaces
{
    public interface ISound
    {
        void Play();
        SoundEffectInstance CreateInstance();

        void SetVolume(float volume);
    }
}

