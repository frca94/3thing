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
        private int velocity;
        public static int gravity = 1; //9.81 rounded ;)
        public Actor(bool inIsActive, Rectangle inPosition, Texture2D inTexture)
            : base(inIsActive, inPosition, inTexture)
        {

        }
        public void Jump()
        {
            velocity = 20;
        }

        public void ApplyPhysics(Foreground foreground) //TODO: Passing in the foreground is inefficient, needs to be changed
        {
            velocity = velocity - gravity; //apply gravity acceleration
            for (int i = 0; i < texture.Width / 5; i++)
            {
                if (foreground.CheckCollisions(i, position.Height) == true) //Need to instance foreground
                {
                    return;
                }
            }
            position.Y = position.Y - velocity;
        }
    }
}
