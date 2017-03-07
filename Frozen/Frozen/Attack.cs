using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frozen
{
    class Attack : IStrategy
    {
        public Animator animator { get; set; }

        public Attack(Animator animator)
        {
            this.animator = animator;
        }
        public void Execute(ref DIRECTION CurrentDirection)
        {
            animator.PlayAnimation("Attack" + CurrentDirection);

            animator.PlayAnimation("AttackTwo" + CurrentDirection);
        }
    }
}
