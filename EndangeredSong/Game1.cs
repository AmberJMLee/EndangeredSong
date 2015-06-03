using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
//using OpenTK;
using System;
using System.Collections;
using System.Diagnostics;

namespace EndangeredSong
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
  //      Song song;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Controls controls;

        Menu menu;
        bool started;
        Camera camera;
        MiniMap map;

        ArrayList undiscoveredHarmonians;
        ArrayList hidingPlaces;
        ArrayList decorations;

        Player player;
        BIOAgent b1;
        Random rand;
        int dimX;
        int dimY;
        int screenWidth;
        int screenHeight;

        SoundEffect song1;
        SoundEffect song2;
        //Texture2D background;



        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Endangered Song";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            IsMouseVisible = false;
            camera = new Camera(GraphicsDevice.Viewport);
            GraphicsDevice.Viewport = new Viewport(0, 0, 4000, 3000);
            //GraphicsDevice.Viewport = new Viewport(0, 0, 1000, 800);
            screenWidth = 980;
            screenHeight = 540;
            graphics.PreferredBackBufferWidth = screenWidth;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = screenHeight;   // set this value to the desired height of your window          
            graphics.ApplyChanges();
            dimX = GraphicsDevice.Viewport.Bounds.Width;
            dimY = GraphicsDevice.Viewport.Bounds.Height;

            undiscoveredHarmonians = new ArrayList();
            hidingPlaces = new ArrayList();
            decorations = new ArrayList();

            player = new Player(300, 250, 200, 120, dimX, dimY);
            b1 = new BIOAgent(600, 300, 200, 350, dimX, dimY);
            menu = new Menu(0, 0, 980, 540);
            map = new MiniMap(400, 300, graphics.GraphicsDevice);
            started = false;
            
            controls = new Controls();
            rand = new Random();

            for (int j = 0; j < 50; j ++ )
            {
                Decor dec = new Decor(rand.Next(0, dimX - 100), rand.Next(0, dimY - 100), 50, 50);
                decorations.Add(dec);
            }

            for (int i = 0; i < 10; i++)    //randomly generate 10 obstacles and harmonians on the map
            {
                Harmonian h = new Harmonian(rand.Next(0, dimX - 200), rand.Next(0, dimY - 200), 200, 120, dimX, dimY);
                HidingPlace p = new HidingPlace(rand.Next(0, dimX - 200), rand.Next(0, dimY - 200), 400, 500, rand.Next(0, 4));
                undiscoveredHarmonians.Add(h);
                hidingPlaces.Add(p);
            }


            song1 = Content.Load<SoundEffect>(@"Harmonian1");
            var songInstance = song1.CreateInstance();
            songInstance.IsLooped = true;
            songInstance.Play();
                

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Content.RootDirectory = "Content";
            spriteBatch = new SpriteBatch(GraphicsDevice);

            b1.LoadContent(this.Content);
            player.LoadContent(this.Content);
            menu.LoadContent(this.Content);            

            for (int j = 0; j < decorations.Count; j++)
                ((Decor)decorations[j]).LoadContent(this.Content);
            for (int i = 0; i < hidingPlaces.Count; i++)                           
                ((HidingPlace)hidingPlaces[i]).LoadContent(this.Content);            
            for (int k = 0; k < undiscoveredHarmonians.Count; k++)
                ((Harmonian)undiscoveredHarmonians[k]).LoadContent(this.Content);            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
                started = true;

            controls.Update();

            if (started)
            {
                camera.Update(gameTime, player, screenWidth, screenHeight);
                
                for (int j = 0; j < decorations.Count; j++ )
                    ((Decor)decorations[j]).Update(controls, gameTime);
                for (int i = 0; i < hidingPlaces.Count; i++)
                    ((HidingPlace)hidingPlaces[i]).Update(controls, gameTime, player);
                for (int k = 0; k < undiscoveredHarmonians.Count; k++ )
                    ((Harmonian)undiscoveredHarmonians[k]).Update(controls, gameTime, player);

                b1.Update(controls, gameTime, player);
                player.Update(controls, gameTime);
                map.Update(graphics.GraphicsDevice, hidingPlaces, undiscoveredHarmonians, player);
            }

            else
            {
                menu.Update();
                camera.Update(gameTime, menu, screenWidth, screenHeight);
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkOliveGreen);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
            
            if (!started)
                menu.Draw(spriteBatch);
            else
            {
                for (int j = 0; j < decorations.Count; j++ )
                    ((Decor)decorations[j]).Draw(spriteBatch);
                for (int i = 0; i < hidingPlaces.Count; i++)  
                    ((HidingPlace)hidingPlaces[i]).Draw(spriteBatch);
                for (int k = 0; k < undiscoveredHarmonians.Count; k ++ )
                    ((Harmonian)undiscoveredHarmonians[k]).Draw(spriteBatch);

                b1.Draw(spriteBatch);
                player.Draw(spriteBatch);
                map.Draw(spriteBatch, (int)(player.getPosition().X + 200), (int)(player.getPosition().Y - 200));
                
            };
                        
            spriteBatch.End();
            
            
            base.Draw(gameTime);
        }
    }
}
