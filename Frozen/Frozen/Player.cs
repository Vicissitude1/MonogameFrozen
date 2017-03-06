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

        public void OnAnimationDone(string animationName)
        {
            if (animationName.Contains("Attack"))
            {
                canMove = true;
            }
            if (animationName.Contains("Idle"))
            {
                canMove = true;
            }
            if (animationName.Contains("Walk"))
            {
                canMove = true;
            }
        }



        public void LoadContent(ContentManager Content)
        {
            animator = (Animator)GameObject.GetComponent("Animator");
            strategy = new Idle(animator);
            CreateAnimation();
        }

        public void CreateAnimation()
        {
           
            animator.CreateAnimation(new Animation(5, 300, 0, 107, 100, 6, Vector2.Zero), "WalkRight");
            animator.CreateAnimation(new Animation(5, 700, 0, 107, 100, 6, Vector2.Zero), "WalkLeft");
            animator.CreateAnimation(new Animation(4, 1, 0, 107, 100, 6, Vector2.Zero), "AttackOneRight");
            animator.CreateAnimation(new Animation(4, 400, 0, 107, 100, 6, Vector2.Zero), "AttackOneLeft");
            animator.CreateAnimation(new Animation(1, 100, 0, 107, 100, 6, Vector2.Zero), "JumpRight");
            animator.CreateAnimation(new Animation(2, 100, 2, 107, 100, 6, Vector2.Zero), "JumpAttackRight");
            animator.CreateAnimation(new Animation(1, 500, 0, 107, 100, 6, Vector2.Zero), "JumpLeft");
            animator.CreateAnimation(new Animation(2, 500, 2, 107, 100, 6, Vector2.Zero), "JumpAttackLeft");
            animator.CreateAnimation(new Animation(3, 200, 0, 107, 100, 6, Vector2.Zero), "AttackTwoRight");
            animator.CreateAnimation(new Animation(3, 600, 0, 107, 100, 6, Vector2.Zero), "AttackTwoLeft");
            //animator.CreateAnimation(new Animation(4, 620, 0, 150, 150, 8, Vector2.Zero), "Crouch");
            animator.CreateAnimation(new Animation(1, 100, 0, 107, 100, 2, Vector2.Zero), "IdleRight");
            animator.CreateAnimation(new Animation(1, 400, 0, 107, 100, 2, Vector2.Zero), "IdleLeft");
            //animator.CreateAnimation(new Animation(3, 1070, 0, 150, 150, 5, Vector2.Zero), "DieLeft");
            //animator.CreateAnimation(new Animation(3, 1070, 3, 150, 150, 5, Vector2.Zero), "DieRight");

            //bitch
            animator.PlayAnimation("IdleRight"); 
            
        }

       
    }
}
