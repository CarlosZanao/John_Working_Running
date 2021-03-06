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

namespace JOHN_WORKING_RUNNING
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private const string AssetName = "JohnSprite";
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        John Jonh;
        Terreno terreno1;
        int x, y;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Jonh = new John(this);
            terreno1 = new Terreno(this);
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
            Jonh.Initialize();
            terreno1.Initialize();
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

            Jonh.LoadContent(this);

            spriteBatch = new SpriteBatch(GraphicsDevice);

            terreno1.LoadContent(this);
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
            
            
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                Jonh.Mover(John.Direcoes.Cima);
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                Jonh.Mover(John.Direcoes.Baixo);
           /* if (Keyboard.GetState().IsKeyDown(Keys.Left))*/
                terreno1.Mover(Terreno.Direcoes.Esquerda);

            // TODO: Add your update logic here
            if (Jonh.BoundingBox.Intersects(terreno1.BoundingBox))
            {
                Jonh.Posicao = new Point(Jonh.Posicao.X, 230);


            }







            Jonh.Update(gameTime);
            terreno1.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Jonh.Draw(gameTime);
            terreno1.Draw(gameTime);
            base.Draw(gameTime);

        }
    }
}
