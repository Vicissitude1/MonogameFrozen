using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frozen
{
    class Player
    {
        private float speed;
        public Animator animator;
        private IStrategy strategy;
        private DIRECTION direction;
    }
}
