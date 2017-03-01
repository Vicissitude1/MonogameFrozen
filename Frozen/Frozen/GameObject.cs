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
            components = new List<Component>();
            AddComponent(transform);
        }

        public void AddComponent(Component component)
        {
            components.Add(component);
        }

       

        public void LoadContent(ContentManager content)
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
            foreach (IUpdateable iu in components.FindAll(c => c is IUpdateable))
                iu.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Component component in components)
            {
                if (component is IDrawable)
                {
                    (component as IDrawable).Draw(spriteBatch);
                }
            }
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
        public Component GetComponent(string component)
        {
            return components.Find(n => n.GetType().Name == component);
        }

    }
}
