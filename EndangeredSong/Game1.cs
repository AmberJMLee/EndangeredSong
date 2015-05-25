using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using OpenTK;
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
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Controls controls;
        Menu menu;
        bool started;
        Camera camera;
        ArrayList undiscoveredHarmonians;
        ArrayList obstacles;
        Harmonian player;
        BIOAgent b1;
        Random rand;
        int dimX;
        int dimY;

        int once;
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
            once = 1;
            camera = new Camera(GraphicsDevice.Viewport);
            GraphicsDevice.Viewport = new Viewport(0, 0, 2000, 1800);
            graphics.PreferredBackBufferWidth = 980;  // set this value to the desired width of your window
            graphics.PreferredBackBufferHeight = 540;   // set this value to the desired height of your window          
            graphics.ApplyChanges();
            dimX = GraphicsDevice.Viewport.Bounds.Width;
            dimY = GraphicsDevice.Viewport.Bounds.Height;
            //Debug.WriteLine(dimX + " " + dimY);
            undiscoveredHarmonians = new ArrayList();
            obstacles = new ArrayList();
            player = new Harmonian(300, 250, 200, 125, dimX, dimY);
            //harmonians.Push(player);
            b1 = new BIOAgent(600, 300, 50, 50, dimX, dimY);
            started = false;
            controls = new Controls();
            rand = new Random();
            menu = new Menu(0, 0, 980, 540);
            for (int i = 0; i < 10; i++)
            {
                Harmonian h;
                h = new Harmonian(rand.Next(0, 1800), rand.Next(0, 1600), 200, 125, dimX, dimY);
                Obstacle o;
                o = new Obstacle(rand.Next(0, 1800), rand.Next(0, 1600), 400, 300);
                undiscoveredHarmonians.Add(h);
                obstacles.Add(o);
            }
           

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            Content.RootDirectory = "Content";
            spriteBatch = new SpriteBatch(GraphicsDevice);

            player.LoadContent(this.Content);
            for (int i = 0; i < 10; i++)
            {
                ((Harmonian)undiscoveredHarmonians[i]).LoadContent(this.Content);
                ((Obstacle)obstacles[i]).LoadContent(this.Content);
            }

            b1.LoadContent(this.Content);
            menu.LoadContent(this.Content);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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
            // TODO: Add your update logic here
            if(Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                started = true;
            }
            menu.Update();

                //the game begins!
                controls.Update();
                camera.Update(gameTime, player);
                player.Update(controls, gameTime);
                for (int i = 0; i < 10; i++)
                {
                    //((Harmonian)undiscoveredHarmonians[i]).Update(controls, gameTime);
                    ((Obstacle)obstacles[i]).Update(controls, gameTime);
                }
                b1.Update(controls, gameTime, player);
                once--;
            
            //Debug.WriteLine(h1.getX() + " " + h1.getY());

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, null, camera.transform);
            
            if (!started)
                menu.Draw(spriteBatch);
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    ((Harmonian)undiscoveredHarmonians[i]).Draw(spriteBatch);
                    ((Obstacle)obstacles[i]).Draw(spriteBatch);
                }
                b1.Draw(spriteBatch);
                player.Draw(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
