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
    class Jump : ILoadable
    {
        Vector2 pos;
        Texture2D sprite;
        bool jumped;
        float speed;
        float acc;

        public Jump(Vector2 pos)
        {
            this.pos = pos;
            jumped = false;
            acc = 0.5f;
        }

        
        public void Update()
        {
            KeyboardState x = Keyboard.GetState();
            if (x.IsKeyDown(Keys.Space) && !jumped)
            {
                speed -= 20f;
                jumped = true;
            }

            if (jumped)
            {
                pos.Y += speed;
                speed += acc;
            }
            if (pos.Y > 400)
            {
                pos.Y = 400f;
                jumped = false;
            }
        }

        public void LoadContent(ContentManager content)
        {
            sprite = content.Load<Texture2D>("TempPlayer");
        }
    }
}
