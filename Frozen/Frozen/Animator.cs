using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;


namespace Frozen
{
    class Animator
    {  
        //fields 
        private SpriteRenderer spriteRenderer;
        private int currentIndex;
        private float timeElapsed;
        private float fps;
        private Rectangle[] rectangles;
        private string animationName;

        public Dictionary<string, Animation> animations;

        public Dictionary<string, Animation> Animations { get { return animations; } set { animations = value; } }

        //constructor
        public Animator()
        {

        }

        public void Update()
        {

        }

        public void CreateAnimation()
        {

        }

        public void PlayAnimation()
        {

        }
    }
}
