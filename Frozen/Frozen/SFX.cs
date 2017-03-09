using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using System;

namespace Frozen
{
    class SFX : ILoadable
    {
        private static SFX instance;
        public static SFX Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SFX();
                }
                return instance;
            }
        }

        public static List<SoundEffect> soundEffects;

        private SFX()
        {

            soundEffects = new List<SoundEffect>();
        }

       
        


       
       
        public void LoadContent(ContentManager content)
        {





            soundEffects.Add(content.Load<SoundEffect>("baggrundstest1"));
            soundEffects.Add(content.Load<SoundEffect>("sound2"));
          

            // Fire and forget play
            soundEffects[0].Play();

            // Play that can be manipulated after the fact
            var instance = soundEffects[0].CreateInstance();
            instance.IsLooped = true;
            instance.Play();
        }
    
    }
}

