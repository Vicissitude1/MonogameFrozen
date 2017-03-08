using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace Frozen
{
    class Floor : IDrawable
    {
        Texture2D texture;
        Vector2 position;
        Rectangle rect;

        public void Initialize(ContentManager Content)
        {
            texture = Content.Load<Texture2D>("FrostFloor1000x100"); //loader vores gulv texture.
            position = new Vector2(-1000, 200);
            rect = texture.Bounds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 30; i++)
            {
                //spriteBatch.Draw(texture, position, Color.White);

                //spriteBatch.Draw(texture, new Vector2((int)i, (int)i), Color.White);

                spriteBatch.Draw(texture, new Vector2((int)position.X + (i * texture.Width), position.Y), rect, Color.White, 0, Vector2.Zero, 1f, SpriteEffects.None, 0.1f);
            }

        }
    }
}
