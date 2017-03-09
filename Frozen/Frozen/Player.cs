using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;

namespace Frozen
{
    class Player : Component, IUpdateable, ILoadable, IAnimateable
    {
        public float Speed { get; private set; }
        public Animator animator;
        public bool canMove;
        public bool canJump;
        private IStrategy strategy;
        private DIRECTION direction;
        int health;



        public Player(GameObject go, float speed, int health) :base(go)
        {
            this.Speed = speed;
            canMove = false;
            canJump = false;
            this.health = health;
            health = 100;
            
        }
        
        //public void Execute(ref DIRECTION CurrendtDirecion)
        //{

        //}


        public void Update()
        {
            KeyboardState keyState = Keyboard.GetState();
            if (canMove)
            {
                if(keyState.IsKeyDown(Keys.A) || keyState.IsKeyDown(Keys.S) || keyState.IsKeyDown(Keys.D))
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

                if (keyState.IsKeyDown(Keys.W))
                {
                    strategy = new Jump(GameObject.transform, GameObject, animator);
                    canMove = false;
                    canJump = false;
                   
                }
                if (keyState.IsKeyDown(Keys.E))
                {
                    strategy = new Attack(animator);
                    canMove = false;

                    SFX.soundEffects[0].CreateInstance().Play();
                    //SFX.Instance.soundEffects
                }
                else if (keyState.IsKeyDown(Keys.Q))
                {
                    strategy = new Attack2(animator);
                    canMove = false;
                    SFX.soundEffects[1].CreateInstance().Play();
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
            if (animationName.Contains("AttackTwo"))
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
            if (animationName.Contains("Crouch"))
            {
                canMove = true;
            }
        }



        public void LoadContent(ContentManager Content)
        {
            animator = (Animator)GameObject.GetComponent("Animator");
            strategy = new Jump(GameObject.transform, GameObject, animator);
            CreateAnimation();
        }

        public void CreateAnimation()
        {
            
            animator.CreateAnimation(new Animation(6, 300, 0, 107, 100, 6, Vector2.Zero), "WalkRight");
            animator.CreateAnimation(new Animation(6, 700, 0, 107, 100, 6, Vector2.Zero), "WalkLeft");
            animator.CreateAnimation(new Animation(5, 1, 0, 107, 100, 6, Vector2.Zero), "AttackRight");
            animator.CreateAnimation(new Animation(5, 400, 0, 107, 100, 6, Vector2.Zero), "AttackLeft");
            animator.CreateAnimation(new Animation(2, 100, 0, 107, 100, 2, Vector2.Zero), "JumpRight");
            animator.CreateAnimation(new Animation(3, 100, 2, 107, 100, 6, Vector2.Zero), "JumpAttackRight");
            animator.CreateAnimation(new Animation(2, 500, 0, 107, 100, 2, Vector2.Zero), "JumpLeft");
            animator.CreateAnimation(new Animation(3, 500, 2, 107, 100, 6, Vector2.Zero), "JumpAttackLeft");
            animator.CreateAnimation(new Animation(4, 200, 0, 107, 100, 6, Vector2.Zero), "AttackTwoRight");
            animator.CreateAnimation(new Animation(4, 600, 0, 107, 100, 6, Vector2.Zero), "AttackTwoLeft");
            //animator.CreateAnimation(new Animation(1, 620, 1, 107, 100, 1, Vector2.Zero), "WalkCrouchLeft");
            //animator.CreateAnimation(new Animation(1, 800, 1, 107, 100, 1, Vector2.Zero), "WalkCrouch");
            animator.CreateAnimation(new Animation(2, 0, 0, 107, 100, 2, Vector2.Zero), "IdleRight");
            animator.CreateAnimation(new Animation(2, 400, 0, 107, 100, 2, Vector2.Zero), "IdleLeft");
            animator.CreateAnimation(new Animation(2, 900, 3, 107, 150, 5, Vector2.Zero), "DieLeft");
            animator.CreateAnimation(new Animation(2, 900, 0, 107, 100, 5, Vector2.Zero), "DieRight");

            animator.PlayAnimation("IdleRight");

            
        }

       
    }
}
