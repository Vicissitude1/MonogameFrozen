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


        public Enemy(GameObject gameObject, float speed) : base(gameObject)
        {
            this.speed = speed;

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
            
        }

        public void CreateAnimations()
        {


            animator.CreateAnimation(new Animation(1, 0, 0, 100, 100, 0, Vector2.Zero), "IdleFront");
            animator.CreateAnimation(new Animation(1, 0, 1, 100, 100, 0, Vector2.Zero), "IdleLeft");
            animator.CreateAnimation(new Animation(1, 0, 2, 100, 100, 0, Vector2.Zero), "IdleRight");
            animator.CreateAnimation(new Animation(1, 0, 3, 100, 100, 0, Vector2.Zero), "IdleBack");
            animator.CreateAnimation( new Animation(4, 100, 0, 100, 100, 5, Vector2.Zero), "WalkFront");
            animator.CreateAnimation( new Animation(4, 100, 4, 100, 100, 5, Vector2.Zero), "WalkBack");
            animator.CreateAnimation( new Animation(4, 200, 0, 100, 100, 5, Vector2.Zero), "WalkLeft");
            animator.CreateAnimation( new Animation(4, 200, 4, 100, 100, 5, Vector2.Zero), "WalkRight");
            animator.CreateAnimation(new Animation(4, 300, 0, 100, 100, 5, Vector2.Zero), "DieBack");
            animator.CreateAnimation(new Animation(4, 300, 4, 100, 100, 5, Vector2.Zero), "DieFront");
            animator.CreateAnimation(new Animation(4, 400, 0, 100, 100, 5, Vector2.Zero), "DieLeft");
            animator.CreateAnimation(new Animation(4, 400, 4, 100, 100, 5, Vector2.Zero), "DieRight");


           

            animator.PlayAnimation("IdleRight");
            animator.PlayAnimation("IdleLeft");


        }


    }
}
