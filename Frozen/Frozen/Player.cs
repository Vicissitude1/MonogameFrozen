using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frozen
{
    class Player
    {
        public float Speed { get; private set; }
        public Animator animator;
        public bool canMove;
        private IStrategy strategy;
        private DIRECTION direction;


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
    }
}
