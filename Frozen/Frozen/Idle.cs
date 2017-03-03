using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frozen
{
    class Idle : IStrategy
    {
        public Animator animator{ get; set; }

        public Idle (Animator animator)
        {
            this.animator = animator;
        }
        public void Execute(ref DIRECTION direction)
        {
            //animator.PlayAnimation("Idle" + direction);
        }

    }
}
