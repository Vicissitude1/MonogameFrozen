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
    class Animation
    {
    
        public Rectangle[] rectangles { get; set; }
        public float Fps { get; set; }
        public Vector2 Offset { get; set; }

        public Animation(int frames, int yPos, int xStartFrame, int width, int height, float fps, Vector2 offset)
        {
            this.rectangles = new Rectangle[frames];
            this.Offset = offset;
            this.Fps = fps;
            for (int i = 0; i < frames; i++)
            {
                rectangles[i] = new Rectangle((i + xStartFrame) * width, yPos, width, height);
            }
        }


    }
}
