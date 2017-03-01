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
    class GameObject
    {
        public Transform transform { get; private set; }
        private List<Component> components;
        private SpriteRenderer spriterenderer;

        public GameObject()
        {

        }

        public void AddComponent(Component component)
        {
                 
        }

        public void GetComponent( string Component)
        {

        }

        public void LoadContant(ContentManager content)
        {
            foreach (Component component in components)
            {
                if (component is ILoadable)
                {
                    (component as ILoadable).LoadContent(content);
                }
            }
        }

        public void Update()
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void OnAnimationDone(string animationName)
        {
            foreach (Component component in components)
            {
                if (component is IAnimateable)
                {
                    (component as IAnimateable).OnAnimationDone(animationName);
                }
            }
        }

    }
}
