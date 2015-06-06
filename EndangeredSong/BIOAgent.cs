﻿using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Diagnostics;
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
        Rectangle rect;

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
            this.rect = new Rectangle(x*10, y*10, width*10, height*10);
	    }
        public Rectangle getRect()
        {
            return this.rect; 
        }
        public Vector2 getPosition()
        {
            return this.pos;
        }
        public void setPosition(Vector2 newPosition)
        {
            this.pos = newPosition;
        }
        public Vector2 getDimension()
        {
            return this.dim;
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
        public void Update(Controls controls, GameTime gameTime, Player player, ArrayList harmonians)
        {
            Rectangle r;

            for (int i = 0; i < harmonians.Count; i++)  //loops through harmonian and checks for death of found, unhidden harmonians
            {
                Harmonian h = (Harmonian)harmonians[i];
                r = new Rectangle((int)h.getPosition().X, (int)h.getPosition().Y, (int)h.getDimension().X, (int)h.getDimension().Y);
                
                if (rect.Intersects(r) && h.getFound() && !h.getHid())
                {
                    h.Die();
                    Debug.WriteLine("HARMONIAN DEATH");
                }
            }

            //checks for player death
            r = new Rectangle((int)player.getPosition().X, (int)player.getPosition().Y, (int)player.getDimension().X, (int)player.getDimension().Y);
            if (rect.Intersects(r))
            {                  
                player.Die();
                Debug.WriteLine("PLAYER DEATH");
            }            
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