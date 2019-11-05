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

namespace Pong_2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Ball ball;
        Texture2D background;
        Paddle firstPlayer;
        Paddle secondPlayer;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D texture = Content.Load<Texture2D>("pongBall");
            ball = new Ball(new Sprite(texture, Vector2.Zero),GraphicsDevice.Viewport.Bounds);
            background = Content.Load<Texture2D>("pongBackground");

            Texture2D paddleTexture = Content.Load<Texture2D>("paddle2a");
            firstPlayer = new Paddle(
                new Sprite(paddleTexture, 
                Vector2.Zero), 
                GraphicsDevice.Viewport.Bounds);

            secondPlayer = new Paddle(
                new Sprite(paddleTexture, 
                new Vector2(GraphicsDevice.Viewport.Width-paddleTexture.Width, 0)), 
                GraphicsDevice.Viewport.Bounds);
            // TODO: use this.Content to load your game content here
        }


        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }


        protected override void Update(GameTime gameTime)
        {
            int screenWidth = GraphicsDevice.Viewport.Width;
            int sreenHeight = GraphicsDevice.Viewport.Height;
            KeyboardState keyboardState = Keyboard.GetState();

            Vector2 screenCenter = new Vector2(screenWidth / 2, sreenHeight / 2);
            if (ball.Position.X > screenWidth || ball.Position.X < 0)
            {
                ball.Reset(GraphicsDevice.Viewport.Bounds);
            }

            if (keyboardState.IsKeyDown(Keys.W))
            {
                firstPlayer.moveUp();
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                firstPlayer.moveDown();
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                secondPlayer.moveUp();
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                secondPlayer.moveDown();
            }
            ball.Update(GraphicsDevice.Viewport.Bounds);
            firstPlayer.Update(ball);
            secondPlayer.Update(ball);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(background, GraphicsDevice.Viewport.Bounds, Color.White);
            firstPlayer.Draw(spriteBatch);
            secondPlayer.Draw(spriteBatch);
            ball.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
