using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeThingGame
{
    class SceneItem
    {
        public bool isActive;
        public Rectangle position;

        public SceneItem(bool inIsActive, Rectangle inPosition)
        {
            isActive = inIsActive;
            position = inPosition;
        }
    }
}
