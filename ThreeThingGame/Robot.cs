using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeThingGame
{
    class Robot : Actor
    {
        public int alertDistance = 500;
        public int movespeed = 3;
        public Robot(bool inIsActive, Rectangle inPosition, Texture2D inTexture)
            : base(inIsActive, inPosition, inTexture)
        {

        }
    }
}
