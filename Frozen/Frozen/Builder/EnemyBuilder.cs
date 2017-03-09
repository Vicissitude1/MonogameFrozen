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
    class EnemyBuilder : IBuilder
    {
        public GameObject gameObject { get;  set; }

        public void BuildGameObject(Vector2 position)
        {

            //Her skal vi bare bruge den enemy vi har fundet, og ha nskal bare sættes ind istedet for SlimeSheet, der kan også
            //blive ændret i tallene

            gameObject = new GameObject(new Vector2(300, 100)); //Vi skal ikke ligge en ny transform til vores builder

            gameObject.AddComponent(new Transform(gameObject, new Vector2(200, 200)));
            gameObject.AddComponent(new SpriteRenderer(gameObject, "SpritesheeptAlmostFinalenemy", 0));
            gameObject.AddComponent(new Enemy(gameObject, 100f, 100));
            gameObject.AddComponent(new Animator(gameObject));
            gameObject.AddComponent(new Collide(gameObject));
        }

        //husk den returne null for bare at fjerne fejlen!
        public GameObject GetResult()
        {
            return gameObject;
        }
    }
}
