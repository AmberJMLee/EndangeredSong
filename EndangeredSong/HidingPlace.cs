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
        Rectangle rect;
        //SpriteFont font;

        public HidingPlace(int x, int y, int width, int height)
	    {
            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;
            this.rect = new Rectangle(x, y, x + width, y + height);
            this.maxCapacity = 0;
            this.currentCapacity = 0;
	    }

        public HidingPlace(int x, int y, int width, int height, int capacity)
        {
            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;
            this.rect = new Rectangle(x, y, x + width, y + height);
            this.maxCapacity = capacity;
            this.currentCapacity = 0;
        }
        
        public Vector2 getPosition()
        {
            return this.pos;
        }

        public void LoadContent(ContentManager content)
        {
            image = content.Load<Texture2D>("emptyrightbigtree.png");
            //font = content.Load<SpriteFont>("Arial");
        }

        public Rectangle getRect()
        {
            return this.rect;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), Color.White);
            //sb.DrawString(font, "hello", this.pos, Color.Black);
        }
        public void Update(Controls controls, GameTime gameTime, Harmonian player)
        {
            if (this.rect.IntersectsWith(player.getRect()));
            
        }
       
    }
}