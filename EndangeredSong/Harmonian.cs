using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Diagnostics;
using Microsoft.Xna.Framework.Audio;
//using System.Drawing;

namespace EndangeredSong
{
    class Harmonian : Sprite
    {
        bool isHid;
        bool isFound;
        int maxX;
        int maxY;
        Rectangle rect;
        int foundPosition;
        string songName;
        bool hasPlayed;
        SoundEffect song;
        SoundEffectInstance s;

        float timer = 23;         
        const float TIMER = 23;

        public Harmonian(int x, int y, int width, int height, int maxX, int maxY, string sn)
	    {            
            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;
            this.maxX = maxX;
            this.maxY = maxY;
            this.rect = new Rectangle(x, y, width/2, height);
            this.isHid = false;
            this.isFound = false;
            this.foundPosition = -1;
            this.songName = sn;
            this.hasPlayed = false;
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
            song = content.Load<SoundEffect>(@songName);

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
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
            timer -= elapsed;

            Move(controls, player);
            if (this.isFound)
<<<<<<< HEAD
                if (timer < 0)
=======
            {
                if (this.hasPlayed == false)
>>>>>>> origin/master
                {
                    s = song.CreateInstance();
                    //s.IsLooped = true;
                    s.Play();
                    timer = TIMER;
                }
                this.isHid = player.isHidden();
            }
            
        }

        public void Move(Controls controls, Player player)
        {
            Vector2 direction = player.getPosition() - this.pos;
            

            if (direction.Length() < 100 && !this.isFound)
            {
                this.foundPosition = player.getNumFound();
                player.foundHarmonian();
                this.isFound = true;
            }
                
            if (this.isFound)
            {
                //direction += player.getFollowingPosition(this.foundPosition % 8);
                if (direction.Length() > 100)
                {
                    direction += player.getFollowingPosition(this.foundPosition % 8);
                    direction.Normalize();
                    this.pos = this.pos + direction * 6;
                }
            }
        }

        //These are method stubs that may be necessary.
        public void BIOAgentsAreComing()
        {

        }
       public void Die()
        {

        }
    }
}