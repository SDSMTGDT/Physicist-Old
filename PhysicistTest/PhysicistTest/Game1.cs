using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

//testing game features!  Can be broken.
namespace PhysicistTest
{
    /// <summary>
    /// A test game for Pysicist features
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //graphical jargon
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D background;

        //background orientation
        Vector2 origin;
        float mapAngle = 0;

        public Game1()
        {
            //set up the graphics manager and content pipeline
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //set the screen properties
            origin = new Vector2(640, 360);
            graphics.PreferredBackBufferWidth = 1280;  // set the width and height of the window
            graphics.PreferredBackBufferHeight = 720;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            background = Content.Load<Texture2D>("maps/TESHTMAP");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            KeyboardState k = Keyboard.GetState();

            //check for game exit
            if (k.IsKeyDown(Keys.Escape))
                this.Exit();

            //check for world rotation
            if (k.IsKeyDown(Keys.Right))
                mapAngle += (float).01;
            if (k.IsKeyDown(Keys.Left))
                mapAngle -= (float).01;

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //set background color
            GraphicsDevice.Clear(Color.White);

            //set the map background
            Rectangle drawMap = new Rectangle(0, 0, 1280, 720);

            //draw stuff
            spriteBatch.Begin();

            //Draw the background
            spriteBatch.Draw(background, origin, drawMap, Color.White, mapAngle, origin, 1, SpriteEffects.None, 1);

            spriteBatch.End();

            
            base.Draw(gameTime);
        }
    }
}
