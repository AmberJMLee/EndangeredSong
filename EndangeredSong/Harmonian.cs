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
        bool isFound;
        int maxX;
        int maxY;
        Rectangle rect;
        int foundPosition;
        public Harmonian(int x, int y, int width, int height, int maxX, int maxY)
	    {            
            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;
            this.maxX = maxX;
            this.maxY = maxY;
            this.rect = new Rectangle(x, y, width, height);
            this.isHid = false;
            this.isFound = false;
            this.foundPosition = -1;
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
            if(!this.isHid)
                sb.Draw(image, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), Color.White);
        }

        public void Update(Controls controls, GameTime gameTime, Player player)
        {
            Move(controls, player);
            if (this.isFound)
                this.isHid = player.isHidden();
            
        }

        public void Move(Controls controls, Player player)
        {
            Vector2 direction = player.getPosition() - this.pos;
            

            if (direction.Length() < 150 && !this.isFound)
            {
                this.foundPosition = player.getNumFound();
                player.foundHarmonian();
                this.isFound = true;
            }
                
            
            if (direction.Length() > 100 && this.isFound)
            {
                direction += player.getFollowingPosition(this.foundPosition % 8);
                direction.Normalize();
                this.pos = this.pos + direction * 5;
            }
            


        }
       
    }
}