using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThreeThingGame
{
    class Foreground : Drawable
    {
        Color[] pixelColours;
        public Foreground(bool inIsActive, Rectangle inPosition, Texture2D inTexture)
            : base(inIsActive, inPosition, inTexture)
        {
            pixelColours = new Color[inTexture.Width * inTexture.Height]; //Store all foreground pixels in a 1D array, row by row
            inTexture.GetData<Color>(pixelColours); //populates the array with RGBA data
        }

        public bool CheckCollisions(int x, int y)
        {
            Vector2 coords = new Vector2((int)x % texture.Width, y / texture.Width); //Get x and y coordinates from 1D array //TODO: is cast needed?
            if (pixelColours[x*y].A != 1) //if pixel is transparent
            {
                //Collide
                return true;
            }
            else
            {
                //No collision
                return false;
            }
            throw new NotImplementedException();
        }
    }
}
