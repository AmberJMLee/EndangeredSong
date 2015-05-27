using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;

namespace EndangeredSong
{
    class HidingPlace : Sprite
    {
        int maxCapacity;
        int currentCapacity;
        string assetName;
        public HidingPlace(int x, int y, int width, int height)
	    {
            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;
	    }
        
        public Vector2 getPosition()
        {
            return this.pos;
        }

        public void LoadContent(ContentManager content)
        {
            image = content.Load<Texture2D>("fullrightbigtree.png");
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), Color.White);
        }
        public void Update(Controls controls, GameTime gameTime)
        {
            //update capacity 
            //bluh
        }
       
    }
}