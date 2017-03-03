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
        private DIRECTION direction;
        bool jump;
        float acc;


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

                else
                {
                    strategy = new Idle(animator);
                }
                if (keyState.IsKeyDown(Keys.Space))
                {
                    strategy = new Attack(animator);
                    canMove = false;
                }
            }
            strategy.Execute(ref direction);
        }

        public void CreateAnimation()
        {
            animator.CreateAnimation(new Animation(6, 300, 1, 107, 100, 6, Vector2.Zero), "IdleFront");
            //animator.CreateAnimation(new Animation(4, 0, 4, 90, 150, 6, Vector2.Zero),"IdleBack");
            //animator.CreateAnimation(new Animation(4, 0, 8, 90, 150, 6, Vector2.Zero),"IdleLeft");
            //animator.CreateAnimation(new Animation(4, 0, 12, 90, 150, 6, Vector2.Zero),"IdleRight");
            //animator.CreateAnimation(new Animation(4, 150, 0, 90, 150, 6, Vector2.Zero),"WalkFront");
            //animator.CreateAnimation(new Animation(4, 150, 4, 90, 150, 6, Vector2.Zero),"WalkBack");
            //animator.CreateAnimation(new Animation(4, 150, 8, 90, 150, 6, Vector2.Zero),"WalkLeft");
            //animator.CreateAnimation(new Animation(4, 150, 12, 90, 150, 6, Vector2.Zero),"WalkRight");
            //animator.CreateAnimation(new Animation(4, 300, 0, 145, 160, 8, new Vector2(-50, 0)),"AttackFront");
            //animator.CreateAnimation(new Animation(4, 465, 0, 170, 155, 8, new Vector2(-20, 0)),"AttackBack");
            //animator.CreateAnimation(new Animation(4, 620, 0, 150, 150, 8, Vector2.Zero),"AttackRight");
            //animator.CreateAnimation(new Animation(4, 770, 0, 150, 150, 8, new Vector2(-60, 0)),"AttackLeft");
            //animator.CreateAnimation(new Animation(3, 920, 0, 150, 150, 5, Vector2.Zero),"DieFront");
            //animator.CreateAnimation(new Animation(3, 920, 3, 150, 150, 5, Vector2.Zero),"DieBack");
            //animator.CreateAnimation(new Animation(3, 1070, 0, 150, 150, 5, Vector2.Zero),"DieLeft");
            //animator.CreateAnimation(new Animation(3, 1070, 3, 150, 150, 5, Vector2.Zero),"DieRight");

            animator.PlayAnimation("IdleFront");

            strategy = new Idle(animator);
        }

        public void OnAnimationDone(string animationName)
        {
            if (animationName.Contains("Attack"))
            {
                canMove = true;
            }
        }

  

        public void LoadContent(ContentManager Content)
        {
            animator = (Animator)GameObject.GetComponent("Animator");
            CreateAnimation();
        }
    }
}
