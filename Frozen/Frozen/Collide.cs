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
    class Collide : Component, ILoadable, IDrawable
    {
        private SpriteRenderer spriteRenderer;
        private Texture2D texture2D;
        public Vector2 position;
        public Vector2 velocity;

        

        public Collide (GameObject gameObject) : base(gameObject)
        {
            this.GameObject = gameObject;
        }

        public Rectangle CollisionBox
        {
            
            get
            {
               
                return new Rectangle
                    (
                        (int)(GameObject.transform.Position.X + spriteRenderer.offset.X),
                        (int)(GameObject.transform.Position.Y + spriteRenderer.offset.Y),
                        spriteRenderer.rectangle.Width,
                        spriteRenderer.rectangle.Height
                    );
            }
        }

        public Collide(Texture2D texture, Vector2 position)
        {
            this.position = position;
            this.texture2D = texture;
        }

        public Collide(Texture2D texture, Vector2 position, Vector2 velocity)
        {
            this.texture2D = texture;
            this.position = position;
            this.velocity = velocity;
        }

        //protected override void LoadContant()
        //{
        //    spriteBatch = new SpriteBatch(GraphicsDevice);

        //    Texture2D wallTexture = Content.Load<Texture2D>("FrostFloor1000x100");

        //}

        public void LoadContent(ContentManager content)
        {
            spriteRenderer = (SpriteRenderer)GameObject.GetComponent("SpriteRenderer");
            texture2D = content.Load<Texture2D>("CollisionTexture.png");


        }
        public void Draw (SpriteBatch spriteBatch)
        {
            Rectangle topLine = new Rectangle(CollisionBox.X, CollisionBox.Y, CollisionBox.Width, 1);
            Rectangle bottomLine = new Rectangle(CollisionBox.X, CollisionBox.Y + CollisionBox.Height, CollisionBox.Width, 1);
            Rectangle rightLine = new Rectangle(CollisionBox.X + CollisionBox.Width, CollisionBox.Y, 1, CollisionBox.Height);
            Rectangle leftLine = new Rectangle(CollisionBox.X, CollisionBox.Y, 1, CollisionBox.Height);
            spriteBatch.Draw(texture2D, topLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture2D, bottomLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture2D, rightLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
            spriteBatch.Draw(texture2D, leftLine, null, Color.Red, 0, Vector2.Zero, SpriteEffects.None, 1);
        
        }
    }
}
