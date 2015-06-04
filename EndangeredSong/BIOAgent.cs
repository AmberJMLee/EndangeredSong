using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
/// <summary>
/// Summary description for Class1
/// </summary>
/// 
namespace EndangeredSong
{
    class BIOAgent : Sprite
    {
	    int maxX;
        int maxY;
        bool isActive;

        int frameRate;

        public BIOAgent(int x, int y, int width, int height, int maxX, int maxY)
	    {
            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;
            this.maxX = maxX;
            this.maxY = maxY;
            this.frameRate = 1;
            this.isActive = false;
	    }
        public Vector2 getPosition()
        {
            return this.pos;
        }
        public void setPosition(Vector2 newPosition)
        {
            this.pos = newPosition;
        }

        public void LoadContent(ContentManager content)
        {
            image = content.Load<Texture2D>("sprite.gif");
        }
        public bool isOnScreen()
        {
            return this.isActive;
        }
        public void Draw(SpriteBatch sb)
        {
            if (isActive)
            {
                sb.Draw(image, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), Color.White);
            }
        }

        public void activate()
        {
            this.isActive = true;
        }

        public void disactivate()
        {
            this.isActive = false;
        }

        public void notActive()
        { 
        
        }
        public void Update(Controls controls, GameTime gameTime, Player player)
        {
            Move(controls, player);
        }

        public void Move(Controls controls, Player player)
        {
            Vector2 direction = player.getPosition() -  this.pos;
            if (direction.Length() > 10)
            {
                direction.Normalize();
                this.pos = this.pos + direction * 6;
            }

        }
    }
}