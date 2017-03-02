﻿using System;
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
    class SpriteRenderer : Component, IDrawable, ILoadable
    
    {
        public Rectangle rectangle { get; set; }
        public Texture2D sprite { get; set; }
        private string spriteName;
        private float layerDepth;
        public Vector2 offset { get; set; }

        public SpriteRenderer(GameObject gameObject, string spriteName, float layerDepth) : base(gameObject)
        {
            this.spriteName = spriteName;
            this.layerDepth = layerDepth;
        }
       
       public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, GameObject.transform.Position + offset, rectangle, Color.BlanchedAlmond);
        }

        
    }
}
