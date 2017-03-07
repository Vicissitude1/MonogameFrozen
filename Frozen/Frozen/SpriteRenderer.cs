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
    class SpriteRenderer : Component, IDrawable, ILoadable
    
    {
        public Rectangle rectangle { get; set; }
        public Texture2D sprite { get; set; }
        private string spriteName;
        private float layerDepth;
        public Vector2 offset { get; set; }


        //test bacgroundscroll
        //The size of the Sprite
        public Rectangle Size;

        //Used to size the Sprite up or down from the original image
        public float Scale = 1.0f;

        public SpriteRenderer(GameObject gameObject, string spriteName, float layerDepth) : base(gameObject)
        {
            this.spriteName = spriteName;
            this.layerDepth = layerDepth;
        }
       
       public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>(spriteName);
            
            //Size = new Rectangle(0, 0, (int)(sprite.Width * Scale), (int)(sprite.Height * Scale));

        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, GameObject.transform.Position + offset, rectangle, Color.BlanchedAlmond, 0f, Vector2.Zero, 1, SpriteEffects.None, 1);
            //spriteBatch.Draw(sprite, GameObject.transform.Position + offset, new Rectangle(0, 0, sprite.Width, sprite.Height), Color.White, 0.0f, Vector2.Zero, Scale, SpriteEffects.None, 0);
        }

        
    }
}
