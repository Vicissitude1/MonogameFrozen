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
    class Animator : Component, IUpdateable
    {  
        //fields 
        private SpriteRenderer spriteRenderer;
        private int currentIndex;
        private float timeElapsed;
        private float fps;
        private Rectangle[] rectangles;
        private string animationName;

        

        public Dictionary<string, Animation> Animations { get; private set; }

        //constructor
        public Animator(GameObject gameObject) : base(gameObject)
        {
            fps = 5;
            this.spriteRenderer = (SpriteRenderer)gameObject.GetComponent("SpriteRenderer");
            Animations = new Dictionary<string, Animation>();
        }

        public void Update()
        {
            timeElapsed += GameWorld.Instance.deltatime;
            currentIndex = (int)(timeElapsed * fps);
            if (currentIndex > rectangles.Length - 1)
            {
                GameObject.OnAnimationDone(animationName);
                timeElapsed = 0;
                currentIndex = 0;
            }
            spriteRenderer.rectangle = rectangles[currentIndex];
        }

        public void CreateAnimation(Animation animation, string name)
        {
            Animations.Add(name, animation);
        }

        public void PlayAnimation(string animationName)
        {
            if (this.animationName != animationName)
            {
                //checks if it's a new animation
                this.rectangles = Animations[animationName].Rectangles;
                //sets the rectangle
                this.spriteRenderer.Rectangle = rectangles[0];
                //sets the offset
                this.spriteRenderer.Offset = Animations[animationName].Offset;
                //sets the animation name
                this.animationName = animationName;
                //sets the fps
                this.fps = Animations[animationName].Fps;
                //resets the animation 

                timeElapsed = 0;
                currentIndex = 0;
            }
    }
}
