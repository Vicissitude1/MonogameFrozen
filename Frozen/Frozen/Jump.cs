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
    class Jump : IStrategy
    {
        Vector2 pos;
        Texture2D sprite;
        bool jumped;
        float speed;
        float acc;
        public Animator animator { get; set; }


        public Jump(Animator animator)
        {
            this.pos = pos;
            jumped = false;
            acc = 0.5f;
            this.animator = animator;
        }

       

        public void Update()
        {
           
        }

        public void Execute(ref DIRECTION CurrentDirection)
        {
            Vector2 translation = Vector2.Zero;

            
            KeyboardState x = Keyboard.GetState();
            if (x.IsKeyDown(Keys.W) && !jumped)
            {
                speed -= 20f;
                jumped = true;
            }

            if (jumped)
            {
                pos.Y += speed;
                speed += acc;
            }
            if (pos.Y > 400)
            {
                pos.Y = 400f;
                jumped = false;
            }


            animator.PlayAnimation("Jump" + CurrentDirection);
        }

    
    }
}
