﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeThingGame
{
    class Actor : Drawable
    {
        private int maxJumpHeight = 150;
        private int velocity;
        int jumpHeight;
        public static int gravity = 1; //9.81 rounded ;)
        public Actor(bool inIsActive, Rectangle inPosition, Texture2D inTexture)
            : base(inIsActive, inPosition, inTexture)
        {

        }
        public void Jump()
        {
            velocity = 20;
        }

        public void ApplyPhysics()
        {
            velocity = velocity - gravity; //apply gravity acceleration
            position.Y = position.Y - velocity;
        }
    }
}
