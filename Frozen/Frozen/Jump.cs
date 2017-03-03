using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frozen
{
    class Jump : IStrategy
    {
        public Animator animator { get; set; }

        public Jump(Animator animator)
        {
            this.animator = animator;
        }
        public void Execute(ref DIRECTION CurrentDirection)
        {
            animator.PlayAnimation("Jump" + CurrentDirection);
        }
    }
}

   