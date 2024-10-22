using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace FNA_Snowfall
{
    public class Snowfall : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D snowflakeTexture;
        private Texture2D backgroundTexture;
        private List<Snowflake> snowflakes;

        private readonly int windowHeight;
        private readonly int windowWidth;
        private readonly Random random = new Random();
        private MouseState previousMouseState;

        public Snowfall()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            windowWidth = graphics.PreferredBackBufferWidth;
            windowHeight = graphics.PreferredBackBufferHeight;

            IsMouseVisible = false;
            graphics.IsFullScreen = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

            snowflakes = new List<Snowflake>();
            for (var i = 0; i < 400; i++)
            {
                var size = (float)random.Next(2, 5) / 100;
                var speed = (float)random.NextDouble() * 50f + 20f;
                var startPosition = new Vector2(random.Next(0, windowWidth), random.Next(0, windowHeight));

                snowflakes.Add(new Snowflake(startPosition, speed, size));
            }

            previousMouseState = Mouse.GetState();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            snowflakeTexture = Content.Load<Texture2D>("snowflake");
            backgroundTexture = Content.Load<Texture2D>("background");
        }

        protected override void Update(GameTime gameTime)
        {
            var currentMouseState = Mouse.GetState();
            if (currentMouseState.X != previousMouseState.X ||
                currentMouseState.Y != previousMouseState.Y ||
                Keyboard.GetState().GetPressedKeys().Length > 0)
            {
                Exit();
            }

            UpdateSnowFlakePosition(gameTime);

            base.Update(gameTime);
        }

        private void UpdateSnowFlakePosition(GameTime gameTime)
        {
            foreach (var snowflake in snowflakes)
            {
                snowflake.Fall(gameTime);
                if (snowflake.Position.Y > windowHeight)
                {
                    snowflake.Position = new Vector2(random.Next(0, windowWidth), -50);
                }
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundTexture, new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.White);

            foreach (var snowflake in snowflakes)
            {
                spriteBatch.Draw(snowflakeTexture, snowflake.Position, null, Color.White, 0f, Vector2.Zero, snowflake.Size, SpriteEffects.None, 0f);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
