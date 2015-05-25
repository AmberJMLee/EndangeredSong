using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace EndangeredSong
{
    class Menu
    {
        bool start;
        private Texture2D GUITexture;
        private Rectangle GUIRect;
        private string assetName;
        private int x, y, width, height;
        public Menu(int x, int y, int width, int height)
        {
            this.assetName = "menubackground";
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
            start = false;
        }
        public void LoadContent(ContentManager content)
        {
            GUITexture = content.Load<Texture2D>(assetName);
            GUIRect = new Rectangle(x, y, width, height);
        }
        public void Update()
        {

        }
      
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(GUITexture, GUIRect, Color.White);
        }
        public void CenterElement(int height, int width)
        {
            GUIRect = new Rectangle((width / 2) - this.GUITexture.Width, (height / 2) - this.GUITexture.Height, this.GUITexture.Width, this.GUITexture.Height);
        }
    }
}
