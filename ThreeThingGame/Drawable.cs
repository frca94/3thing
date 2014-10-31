using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeThingGame
{
    class Drawable : SceneItem
    {
        public Texture2D texture;

        public Drawable(bool inIsActive, Rectangle inPosition, Texture2D inTexture)
            : base(inIsActive, inPosition)
        {
            texture = inTexture;
        }
    }
}
