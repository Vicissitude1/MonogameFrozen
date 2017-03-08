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
    class Enemy : Component, IUpdateable, ILoadable, IAnimateable, IStrategy
    {
        private DIRECTION currentDirection;
        private Animator animator;
        private float speed;
        private IStrategy strategy;
        int health;


        public Enemy(GameObject gameObject, float speed, int Health) : base(gameObject)
        {
            this.speed = speed;
            speed = 10;
            this.health = Health;
            health = 100;
            

        }


        public void Execute(ref DIRECTION currentDirection)
        {
           


        }

        public void LoadContent(ContentManager content)
        {
            this.animator = (Animator)GameObject.GetComponent("Animator");

            CreateAnimations();
        }

        public void OnAnimationDone(string animationName)
        {
            
        }

        public void Update()
        {
            //Husk at alt skal hentes gennem noget andet så for at få player position 
             Vector2 V = GameWorld.Instance.gos.Find(g => g.GetComponent("Player") != null).transform.Position - GameObject.transform.Position;

            currentDirection = V.X > 0 ? DIRECTION.Right : DIRECTION.Left;
            animator.PlayAnimation("Walk" + currentDirection);
          
            //mums = V som er lig med afstanden mellem spiller og fjende
            if (V.Length() <= 7)
            {
                

            // animator.PlayAnimation("Attack" + currentDirection || "AttackTwo" + currentDirection);


            }
            

            V.Normalize();
            GameObject.transform.Translate(V * speed * GameWorld.Instance.deltaTime);
            
       
        }

        public void CreateAnimations()
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
            animator.CreateAnimation(new Animation(1, 620, 1, 107, 100, 1, Vector2.Zero), "CrouchLeft");
            animator.CreateAnimation(new Animation(1, 800, 0, 107, 100, 1, Vector2.Zero), "CroucRight");
            animator.CreateAnimation(new Animation(2, 0, 0, 107, 100, 2, Vector2.Zero), "IdleRight");
            animator.CreateAnimation(new Animation(2, 400, 0, 107, 100, 2, Vector2.Zero), "IdleLeft");
            animator.CreateAnimation(new Animation(2, 900, 3, 107, 150, 5, Vector2.Zero), "DieLeft");
            animator.CreateAnimation(new Animation(2, 900, 0, 107, 100, 5, Vector2.Zero), "DieRight");





            animator.PlayAnimation("IdleLeft");


        }


    }
}
