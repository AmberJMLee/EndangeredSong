using System;
using System.Collections.Generic;
using Menu;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
namespace EndangeredSong
{
    public class MainMenu
    {
        List<GUIElement> main = new List<GUIElement>();
        public MainMenu()
        {
            main.Add(new GUIElement("menubackground"));
        }

        public void LoadContent(ContentManager content)
        {
            foreach (GUIElement element in main)
            {
                element.LoadContent(content);
            }
        }
        public void Start()
        {
            foreach(GUIElement element in main)
            {
                element.Start();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach(GUIElement element in main)
            {
                element.Draw(spriteBatch);
            }
        }
    }
}
