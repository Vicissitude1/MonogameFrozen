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
    class Jump : IStrategy
    {
        //Vector2 pos;
        //Texture2D sprite;
        public bool jumped;
        public float speed;
        public float acc;
        public Animator animator { get; set; }
        private GameObject gameObject;
        private Transform transform;
        public Player player;



        public Jump(Transform transform, GameObject gameObject, Animator animator)
        {
            jumped = false;
            acc = 0.5f;
            this.animator = animator;
            this.gameObject = gameObject;
            this.animator = animator;
            this.transform = transform;
            player = (Player)gameObject.GetComponent("Player");

        }

       

        public void Update()
        {
           
        }

        public void Execute(ref DIRECTION CurrentDirection)
        {
            Vector2 translation = Vector2.Zero; //Fjernede keybord knap W YO
            
            if (!jumped)
            {
                speed -= 15f;
                jumped = true;
            }

            KeyboardState keyState = Keyboard.GetState();

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

            if (jumped)
            {
                translation.Y = speed;
                transform.Translate(translation);
                speed += acc;
            }
            if (transform.Position.Y > 90)
            {
                transform.Translate(new Vector2(0, -1));
                jumped = false;

                player.canMove = true;
            }
           



            animator.PlayAnimation("Jump" + CurrentDirection);
        }

    
    }
}
