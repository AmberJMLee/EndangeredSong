using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using System.Diagnostics;


namespace EndangeredSong
{
    class HidingPlace : Sprite
    {
        int maxCapacity;
        int currentCapacity;

        Rectangle rect;
        //SpriteFont font;

        public HidingPlace(int x, int y, int width, int height)
	    {
            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;
            this.rect = new Rectangle(x, y, width, height);
            this.maxCapacity = 0;
            this.currentCapacity = 0;
	    }

        public HidingPlace(int x, int y, int width, int height, int capacity)
        {
            this.pos.X = x;
            this.pos.Y = y;
            this.dim.X = width;
            this.dim.Y = height;
            this.rect = new Rectangle(x + 100, y + 75, width - 200, height - 200);
            this.maxCapacity = capacity;
            this.currentCapacity = 0;
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
            image = content.Load<Texture2D>("emptyrightbigtree.png");
        }

        public Rectangle getRect()
        {
            return this.rect;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(image, new Rectangle((int)pos.X, (int)pos.Y, (int)dim.X, (int)dim.Y), Color.White);
        }
        public void Update(Controls controls, GameTime gameTime, Player player)
        {
            Rectangle r = new Rectangle((int)player.getPosition().X, (int)player.getPosition().Y, (int)player.getDimension().X/2, (int)player.getDimension().Y);

            if (controls.onPress(Keys.Space, Buttons.A) && rect.Intersects(r))
            {
                player.Hide();
            }
            
        }
       
    }
}