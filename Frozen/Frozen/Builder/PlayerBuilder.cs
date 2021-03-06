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
    class PlayerBuilder : IBuilder
    {
        public GameObject gameObject { get; set; }

        public void BuildGameObject(Vector2 position)
        {
            gameObject = new GameObject(new Vector2(0, 0));

            gameObject.AddComponent(new Transform(gameObject, new Vector2(50 , 300)));
            gameObject.AddComponent(new SpriteRenderer(gameObject, "spritesheetfinal", 1));
            gameObject.AddComponent(new Player(gameObject, 101f, 100));
            gameObject.AddComponent(new Animator(gameObject));
            gameObject.AddComponent(new Collide(gameObject));
        }
        
        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
