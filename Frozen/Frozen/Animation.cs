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
    class Animation
    {
        private float fps;
        private Vector2 offset;
        private Rectangle[] rectangles;

        public float Fps { get { return fps; } set { fps = value; } }
        public Vector2 Offset { get { return offset; } set { offset = value; } }

        public Animation()
        {

        }

    }
}
