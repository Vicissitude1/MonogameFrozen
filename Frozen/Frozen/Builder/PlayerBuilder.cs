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
            gameObject = new GameObject();

            gameObject.AddComponent(new Transform(gameObject, new Vector2(0,0)));
            gameObject.AddComponent(new SpriteRenderer(gameObject, "spritesheetfinal", 1));
            gameObject.AddComponent(new Player(gameObject, 200f));
            gameObject.AddComponent(new Animator(gameObject));
        }
        
        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
