using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace EndangeredSong
{
    class MiniMap
    {
        //System.Drawing.Bitmap map;
        Texture2D tex;
        Color[] pixels;
        int width;
        int height;
        public MiniMap(int width, int height, GraphicsDevice g)
        {
            //map = new System.Drawing.Bitmap(width, height);
            //this.setAllPixels(System.Drawing.Color.DarkGreen);
            this.width = width;
            this.height = height;
            tex = new Texture2D(g, width, height, false, SurfaceFormat.Color);
            pixels = new Color[width * height];
            this.setAllPixels(System.Drawing.Color.DarkGreen);
        }
        public void setAllPixels(System.Drawing.Color c)
        {
        //    for (int x = 0; x < map.Width; x++)
        //        for (int y = 0; y < map.Height; y++)
        //            map.SetPixel(x, y, c);        

            for (int y = 0; y < this.height; y++)
            {
                for (int x = 0; x < this.width; x++)
                {
                    //System.Drawing.Color c = System.Drawing.Color.DarkGreen;
                    pixels[(y * this.width) + x] = new Color(c.R, c.G, c.B, c.A);
                }
            }

        }


        public void setPixel(int x, int y, System.Drawing.Color c)
        {
            if (x < width && y < height && x >= 0 && y >= 0)
            //Debug.WriteLine(x + " " + y + " " + (y * this.width) + x);
            pixels[(y * this.width) + x] = new Color(c.R, c.G, c.B, c.A);
                
        }

        public void Update(GraphicsDevice g, ArrayList hidingPlaces, ArrayList harmonians, ArrayList water, Player player)
        {
            int x1, x2, y1, y2;

            this.setAllPixels(System.Drawing.Color.DarkGreen);
            for(int i = 0; i < hidingPlaces.Count; i++)
            {
                
                x1 = (int)((HidingPlace)hidingPlaces[i]).getPosition().X / 20;
                y1 = (int)((HidingPlace)hidingPlaces[i]).getPosition().Y / 20;
                x2 = x1+(int)((HidingPlace)hidingPlaces[i]).getDimension().X / 20;
                y2 = y1+(int)((HidingPlace)hidingPlaces[i]).getDimension().Y / 20;
                //Debug.WriteLine(x1 + " " + y1 + "  " + x2 + " " + y2);
                for (int x = x1; x < x2; x++)
                    for (int y = y1; y < y2; y++)
                    {
                        this.setPixel(x, y, System.Drawing.Color.LightGreen);
                        
                    }
            }
            
            for (int i = 0; i < harmonians.Count; i++)
            {
                x1 = (int)((Harmonian)harmonians[i]).getPosition().X / 20;
                y1 = (int)((Harmonian)harmonians[i]).getPosition().Y / 20;
                x2 = x1+(int)((Harmonian)harmonians[i]).getDimension().X / 20;
                y2 = y1+(int)((Harmonian)harmonians[i]).getDimension().Y / 20;
                for (int x = x1; x < x2; x++)
                    for (int y = y1; y < y2; y++)
                        this.setPixel(x, y, System.Drawing.Color.Orange);
            }
            for (int i = 0; i < water.Count; i++)
            {
                x1 = (int)((Water)water[i]).getPosition().X / 20;
                y1 = (int)((Water)water[i]).getPosition().Y / 20;
                x2 = x1 + (int)((Water)water[i]).getDimension().X / 20;
                y2 = y1 + (int)((Water)water[i]).getDimension().Y / 20;
                for (int x = x1; x < x2; x++)
                    for (int y = y1; y < y2; y++)
                        this.setPixel(x, y, System.Drawing.Color.Blue);
            }
            x1 = (int)player.getPosition().X / 20;
            y1 = (int)player.getPosition().Y / 20;
            x2 = x1+(int)player.getDimension().X / 20;
            y2 = y1+(int)player.getDimension().Y / 20;
            for (int x = x1; x < x2; x++)
                for (int y = y1; y < y2; y++)
                    this.setPixel(x, y, System.Drawing.Color.Red);

            //convertBitmap(g);
            tex.SetData<Color>(pixels);
            //Debug.WriteLine("hello");
        }
        public void Draw(SpriteBatch sb, int posX, int posY)
        {           
            //sb.Draw(tex, new Rectangle(posX, posY, this.map.Width, this.map.Height), Color.White);
            sb.Draw(tex, new Rectangle(posX, posY, this.width, this.height), Color.White);
        }

        //public System.Drawing.Bitmap getMap()
        //{
        //    return this.map;
        //}
        //public void convertBitmap(GraphicsDevice g)
        //{
        //    Color[] pixels = new Color[map.Width * map.Height];
        //    for (int y = 0; y < map.Height; y++)
        //    {
        //        for (int x = 0; x < map.Width; x++)
        //        {
        //            System.Drawing.Color c = map.GetPixel(x, y);
        //            pixels[(y * map.Width) + x] = new Color(c.R, c.G, c.B, c.A);
        //        }
        //    }

        //    tex.SetData<Color>(pixels);
        //}

    }
}
