using Microsoft.Xna.Framework;
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
        public void Jump() //TODO: Make it update with the frames
        {
            velocity = 800;
            /*
            if (jumpHeight > 0)
            {
                return;
            }
            if (jumpHeight < maxJumpHeight)
            {
                this.position.Y -= 20;
                jumpHeight += 20;
            }*/
        }

        public void ApplyPhysics()
        {
            //if (this.velocity >= 0)
            //{
                this.velocity -= gravity;
                if (this.position.Y <= 800)
                {
                    this.position.Y += velocity;
                }
            //}
        }
    }
}
