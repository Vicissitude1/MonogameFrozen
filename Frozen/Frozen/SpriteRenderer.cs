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
    class SpriteRenderer
    {
        public Rectangle rectangle { get; private set; }
        public Texture2D sprite { get; private set; }
        private string spriteName;
        private float layerDepth;
        private Vector2 offset;

        public SpriteRenderer(GameObject gameObject, string spriteName, float layerDepth)
        {

        }
        public void LoadContent()
        {

        }

        public void Draw()
        {

        }
    }
}
