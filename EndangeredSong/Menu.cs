using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace Menu
{
    class GUIElement
    {
        bool start;
        private Texture2D GUITexture;
        private Rectangle GUIRect;
        private string assetName;
        public GUIElement(string aN)
        {
            this.assetName = aN;
            start = false;
        }
        public void LoadContent(ContentManager content)
        {
            GUITexture = content.Load<Texture2D>(assetName);
            GUIRect = new Rectangle(-250, -200, 1000, 520);
        }
        public void Update()
        {

        }
        public void Start()
        {
            GUIRect = new Rectangle(-5000, -5000, 5, 5);
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
