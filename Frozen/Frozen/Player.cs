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
    class Player : Component, IUpdateable, ILoadable, IAnimateable
    {
        public float Speed { get; private set; }
        public Animator animator;
        public bool canMove;
        private IStrategy strategy;
        public DIRECTION direction { get; private set; }


        public Player(GameObject go, float speed) :base(go)
        {
            this.Speed = speed;
            canMove = true;
        }
        
        public void Execute(ref DIRECTION CurrendtDirecion)
        {

        }


        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (canMove)
            {
                if(keyState.IsKeyDown(Keys.W) || keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.D))
                {
                    if(!(strategy is Walk))
                    {
                        strategy = new Walk(GameObject.transform, GameObject, animator);
                    }
                }


            }
        }

        public void CreateAnimation()
        {
            //animator.CreateAnimation(new Animation(4, 0, 0, 90, 150, 6, Vector2.Zero), "IdleFront");
            //animator.PlayAnimation("IdleFront");
        }

        public void OnAnimationDone()
        {

        }

        public void Move()
        {

        }

        public void LoadContent(ContentManager Content)
        {

        }
    }
}
