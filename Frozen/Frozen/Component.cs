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
          abstract class Component
    {
        public GameObject GameObject { get; private set; }

        public Component(GameObject go)
        {
            this.GameObject = go;
        }

        public Component()
        {

        }




    }
}
