using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frozen
{
    class GameObject
    {

        public Transform transform { get; private set; }
        public SpriteRenderer spirteRenderer { get; private set; }
        public Player player { get; private set; }
        public Animator animator { get; private set; }


    }
}
