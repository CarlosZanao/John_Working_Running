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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Terreno : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public enum Direcoes {Direita, Esquerda }
        public enum Estados { Idle, Andando }

        private const string AssetName = "Terreno";
        SpriteBatch spriteBatch;
        public Texture2D terreno;
        Direcoes direcao;
        public int somaPos;
        public Rectangle BoundingBox { get; set; }
        public Point Posicao { get; set; }
        Point spriteSize;
        //Texture2D Terreno1;

        public Terreno(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            spriteSize = new Point(838, 200);
            Posicao = new Point(0, 350);
            BoundingBox = new Rectangle(Posicao.X, Posicao.Y, spriteSize.X, spriteSize.Y);
        }
        public Terreno(Game game, Point argposicao)
           : base(game)
        {
            Posicao = argposicao;
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
            somaPos = 1;
        }

        public void LoadContent(Game game)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            terreno = game.Content.Load<Texture2D>(AssetName);

        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            if (Posicao.X <= -(terreno.Width))
            {
                Posicao = new Point(0, 351);
            }
            BoundingBox = new Rectangle(Posicao.X, Posicao.Y, spriteSize.X, spriteSize.Y);
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
                spriteBatch.Draw(
                terreno,
                new Rectangle(Posicao.X, Posicao.Y, terreno.Width, terreno.Height),
                Color.White
                );
            spriteBatch.Draw(
                terreno,
                new Rectangle(Posicao.X + 830, Posicao.Y, terreno.Width, terreno.Height),
                Color.White
                );

            spriteBatch.End();
            base.Draw(gameTime);
        }
       public void Mover(Direcoes argdirecao)
        {
            direcao = argdirecao;
            switch (argdirecao)
            {
                case Direcoes.Esquerda: Posicao = new Point(Posicao.X - 2, Posicao.Y); break;
                /*case Direcoes.Direita: Posicao = new Point(Posicao.X + 2, Posicao.Y); break;*/
            }
        }
    }
}
