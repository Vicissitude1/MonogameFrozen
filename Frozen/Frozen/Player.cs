using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


        public Player()
        {

        }
        
        public void Execute(ref DIRECTION CurrendtDirecion)
        {

        }


        public void Update()
        {

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
