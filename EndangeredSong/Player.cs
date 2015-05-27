using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Diagnostics;
using System.Drawing;

namespace EndangeredSong
{
    class Player : Sprite
    {  
   
        bool isHid;
        int maxX;
        int maxY;
        
        public Player (int x, int y, int width, int height, int maxX, int maxY)
	    {
            
            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;

            this.maxX = maxX;
            this.maxY = maxY;

            this.isHid = false;
	    }
       
        public Vector2 getPosition()
        {
            return this.pos;
        }
        public Vector2 getDimension()
        {
            return this.dim;
        }
        public void LoadContent(ContentManager content)
        {
            image = content.Load<Texture2D>("Harmonian.png");
        }

        public void Hide()
        {
            this.isHid = !this.isHid;
        }
        public void Draw(SpriteBatch sb)
        {
            if(!this.isHid)
                sb.Draw(image, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), Color.White);
        }

        public void Update(Controls controls, GameTime gameTime)
        {
            Move(controls);
        }

        public void Move(Controls controls)
        {

            if(!this.isHid)
            {
                Vector2 direction = new Vector2();
            
                if (controls.isPressed(Keys.Right, Buttons.DPadRight) && this.pos.X < maxX-this.dim.X)
                    direction.X = 1;
                if (controls.isPressed(Keys.Left, Buttons.DPadLeft) && this.pos.X > 0)
                    direction.X = -1;
                if (controls.isPressed(Keys.Up, Buttons.DPadUp) && this.pos.Y > 0)
                    direction.Y = -1;
                if (controls.isPressed(Keys.Down, Buttons.DPadDown) && this.pos.Y < maxY-this.dim.Y)
                    direction.Y = 1;

                if (Math.Abs((int)direction.Y) > 0)
                    if (Math.Abs((int)direction.X) > 0)
                        direction.Normalize();

            this.pos.X += (int)(direction.X * 10);
            this.pos.Y += (int)(direction.Y * 10);
            }


        }
       
    }

}
