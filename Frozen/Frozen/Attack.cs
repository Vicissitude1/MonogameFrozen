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

            //animator.PlayAnimation("AttackTwo" + CurrentDirection);
        }
    }
}
