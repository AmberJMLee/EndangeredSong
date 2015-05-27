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
    class Harmonian : Sprite
    {
        //string musicFile;
        bool isHid;
        int maxX;
        int maxY;
        bool isPlayer;
        public Harmonian(int x, int y, int width, int height, int maxX, int maxY)
	    {
            
            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;
            this.rect = new Rectangle(x, y, x + width, y + height);
            this.maxX = maxX;
            this.maxY = maxY;
            this.isPlayer = false;
            this.isHid = false;
	    }
        public Harmonian(int x, int y, int width, int height, int maxX, int maxY, bool player)
        {

            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;
            this.rect = new Rectangle(x, y, x + width, y + height);
            this.maxX = maxX;
            this.maxY = maxY;
            this.isPlayer = player;
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
        public Rectangle getRect()
        {
            return this.rect;
        }
        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), Color.White);
        }

        public void Update(Controls controls, GameTime gameTime, Harmonian player)
        {
            Move(controls);
        }

        public void Move(Controls controls)
        {
            if(this.isPlayer && !this.isHid)
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