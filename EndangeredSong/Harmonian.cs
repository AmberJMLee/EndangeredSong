using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace EndangeredSong
{
    class Harmonian : Sprite
    {
        string musicFile;
        bool isHid;
        int maxX;
        int maxY;

        public Harmonian(int x, int y, int width, int height, int maxX, int maxY)
	    {
            this.spriteX = x;
            this.spriteY = y;
            this.spriteWidth = width;
            this.spriteHeight = height;
            this.maxX = maxX;
            this.maxY = maxY;
            musicFile = "";
	    }
        public int getX()
        {
            return spriteX;
        }
        public int getY()
        {
            return spriteY;
        }
        public void setX(int x)
        {
            spriteX = x;
        }
        public void setY(int y)
        {
            spriteY = y;
        }

        public void LoadContent(ContentManager content)
        {
            image = content.Load<Texture2D>("Harmonian.png");
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle(spriteX, spriteY, spriteWidth, spriteHeight), Color.White);
        }

        public void Update(Controls controls, GameTime gameTime)
        {
            Move(controls);
        }

        public void Move(Controls controls)
        {

            if (controls.isPressed(Keys.D, Buttons.DPadRight) && this.spriteX < maxX-this.spriteWidth)
                this.spriteX += 10;
            if (controls.isPressed(Keys.A, Buttons.DPadLeft) && this.spriteX > 0)
                this.spriteX -= 10;
            if (controls.isPressed(Keys.W, Buttons.DPadUp) && this.spriteY > 0)
                this.spriteY -= 10;
            if (controls.isPressed(Keys.S, Buttons.DPadDown) && this.spriteY < maxY-this.spriteHeight)
                this.spriteY += 10;

        }
       
    }
}