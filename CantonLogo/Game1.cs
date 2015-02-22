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

namespace CantonLogo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D cantonTexture;
        Rectangle cantonRect;

        double cantonXPos = 0.0;
        double cantonYPos = 0.0;
        double cantonWidth = 0.0;
        double cantonHeight = 0.0;

       int cantonRectXPos = 0;
       int cantonRectYPos = 0;
       int cantonRectWidth = 0;
       int cantonRectHeight = 0;
       bool cantonShrink = true;
       const double SHRINK_PERCENTAGE = 0.01;
       Random random = new Random();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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

            cantonRectXPos = 0;
            cantonRectYPos = 0;
            cantonRectWidth = GraphicsDevice.Viewport.Width;
            cantonRectHeight = GraphicsDevice.Viewport.Height;

           /* cantonXPos = 0;
            cantonYPos = 0;
            cantonWidth = GraphicsDevice.Viewport.Width;
            cantonHeight = GraphicsDevice.Viewport.Height;
            */
            cantonXPos = cantonRect.X + cantonRect.Width;
            cantonYPos = cantonRect.Y + cantonRect.Height;

            cantonRect = new Rectangle(cantonRectXPos, cantonRectYPos, cantonRectWidth, cantonRectHeight);
            

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            cantonTexture = this.Content.Load<Texture2D>("canton");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here

           
           // cantonWidth = 0.0;
           // cantonHeight = 0.0;
        //    rect.Width -= Math.Round(rect.Width * SHRINK_PERCENTAGE);


            if (cantonXPos < GraphicsDevice.Viewport.Width / 2) cantonShrink = false;
            if (cantonXPos > 0) cantonShrink = true;
            if (cantonShrink == true) { cantonRect.X += 1; cantonRect.Width -= 2;
            cantonXPos = cantonRect.X + cantonRect.Width;
            cantonYPos = cantonRect.Y + cantonRect.Height;
            }

            else { cantonRect.X -= 1; cantonRect.Width += 2;  
               cantonXPos = cantonRect.Width - cantonRect.X;
               cantonYPos = cantonRect.Height - cantonRect.Y;
            }


            if (cantonYPos < GraphicsDevice.Viewport.Height / 2) cantonShrink = false;
            if (cantonYPos > 0) cantonShrink = true;
            if (cantonShrink == true)
            {
                //(int)Math.Round(cantonRect.Width * SHRINK_PERCENTAGE)
                cantonRect.Y += 1; cantonRect.Width -= 2;
                cantonXPos = cantonRect.X + cantonRect.Width;
                cantonYPos = cantonRect.Y + cantonRect.Height;
            }

            else
            {
                cantonRect.X += 1; cantonRect.Width -= 2;  
                cantonXPos = cantonRect.Width - cantonRect.X;
               cantonYPos = cantonRect.Height - cantonRect.Y;
            }



            /*

            if (cantonWidth < GraphicsDevice.Viewport.Width / 2) cantonShrink = false;
            if (cantonXPos > 0) cantonShrink = true;
            if (cantonShrink == true) { cantonRect.X += 1; cantonRect.X += 2; cantonRect.Width -= 2; cantonRect.Height -= 2; }

            else { cantonRect.X -= 2; cantonRect.X -= 2; cantonRect.Width += 2; cantonRect.Height += 2; }

            /*
            if (cantonRect.Y + cantonRect.Height > GraphicsDevice.Viewport.Height) cantonShrink = false;
            if (cantonRect.Y < 0) cantonShrink = true;
            if (cantonShrink == true) cantonRect.Y += random.Next(5, 10);
            else cantonRect.Y -= random.Next(5, 10);
        
            */

            /*
            cantonRectXPos++;
            cantonRectYPos++;
            cantonRectWidth--;
            cantonRectHeight--;
            */

            //cantonRect = new Rectangle(cantonRectXPos, cantonRectYPos, cantonRectWidth, cantonRectHeight);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            spriteBatch.Draw(cantonTexture, cantonRect, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
