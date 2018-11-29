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
    public class John : Microsoft.Xna.Framework.DrawableGameComponent
    {
        public enum Direcoes { Cima, Baixo }
        public enum Estados { Idle, Andando }
        SpriteBatch spriteBatch;
        Texture2D Jonh;
        Direcoes direcao;
        public Point Posicao { get; set; }


        public John(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
            Posicao = new Point(150, 50);
        }
        public John(Game game, Point argposicao)
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
        }
        public void LoadContent(Game game)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Jonh = game.Content.Load<Texture2D>("JohnSprite");
            
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);

        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(
            Jonh,
            new Rectangle(100, Posicao.Y, Jonh.Width, Jonh.Height),
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
                case Direcoes.Cima: Posicao = new Point(Posicao.X, Posicao.Y - 10); break;
                case Direcoes.Baixo: Posicao = new Point(Posicao.X, Posicao.Y + 10); break;
                
            }
        }
        

    }
}
