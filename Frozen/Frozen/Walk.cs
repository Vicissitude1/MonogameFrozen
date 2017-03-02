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
    class Walk : IStrategy
    {
        private GameObject gameObject;
        private Animator animator;
        private DIRECTION direction;
        private Transform transform;
        public Player player;

        public Walk(Transform transform, GameObject gameObject, Animator animator)
        {
            this.gameObject = gameObject;
            this.animator = animator;
            this.transform = transform;
            this.player = (Player)gameObject.GetComponent("Player"); 
        }

        public void Execute(ref DIRECTION CurrentDirection)
        {
            Vector2 translation = Vector2.Zero;

            KeyboardState keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.W))
            {
                translation += new Vector2(0, -1);
                CurrentDirection = DIRECTION.Back;

            }
            if (keyState.IsKeyDown(Keys.S))
            {
                translation += new Vector2(0, 1);
                CurrentDirection = DIRECTION.Front;

            }
            if (keyState.IsKeyDown(Keys.A))
            {
                translation += new Vector2(-1, 0);
                CurrentDirection = DIRECTION.Left;

            }
            if (keyState.IsKeyDown(Keys.D))
            {
                translation += new Vector2(1, 0);
                CurrentDirection = DIRECTION.Right;
                

            }




            gameObject.transform.Translate(translation * GameWorld.Instance.deltaTime * player.Speed);
            animator.PlayAnimation("Walk" + CurrentDirection);
        }
    }
}
