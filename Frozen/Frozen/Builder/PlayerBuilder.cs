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
    class PlayerBuilder
    {
        public GameObject gameObject { get; set; }

        public void BuildGameObject(Vector2 position)
        {

        }
        // den skal retrun GameObject, men lige pt returner den null for ikke at få fejl
        public GameObject GetResult()
        {
            return null;
        }
    }
}
