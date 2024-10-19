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
        private List<Snowflake> snowflakes;

        private const int WindowHeight = 1920;
        private const int WindowWidth = 1080;
        private readonly Random random = new Random();

        public Snowfall()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            snowflakeTexture = Content.Load<Texture2D>("snowflake");
            snowflakes = new List<Snowflake>();

            for (var i = 0; i < 200; i++)
            {
                var size = (float)random.Next(3, 7) / 100;
                var speed = (float)random.NextDouble() * 50f + 20f;
                var startPosition = new Vector2(random.Next(0, WindowWidth), random.Next(0, WindowHeight));

                snowflakes.Add(new Snowflake(snowflakeTexture, startPosition, speed, size));
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach (var snowflake in snowflakes)
            {
                snowflake.Fall(gameTime);
                if (snowflake.position.Y > WindowHeight)
                {
                    snowflake.position = new Vector2(random.Next(0, WindowWidth), -50);
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            foreach (var snowflake in snowflakes)
            {
                snowflake.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
