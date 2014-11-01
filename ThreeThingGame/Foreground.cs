using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ThreeThingGame
{
    class Foreground : Drawable
    {
        // Create a Bitmap object from an image file.
        System.Drawing.Bitmap myBitmap = new System.Drawing.Bitmap("IMG/foregroundCollisions.png"); //Seperate file due to foreground.png being needed elsewhere
        public Foreground(bool inIsActive, Rectangle inPosition, Texture2D inTexture)
            : base(inIsActive, inPosition, inTexture)
        {
        }

        public bool CheckCollisions(int x, int y)
        {
            //Vector2 coords = new Vector2((int)x % texture.Width, y / texture.Width); //Get x and y coordinates from 1D array //TODO: is cast needed?

            // Get the color of a pixel within myBitmap.
            System.Drawing.Color pixelColor = myBitmap.GetPixel(x, y);
            if (pixelColor.A == 0) //if pixel is transparent
            {
                //No collision
                return false;
            }
            else
            {
                //Collide
                return true;
            }
            throw new NotImplementedException();
        }
    }
}
