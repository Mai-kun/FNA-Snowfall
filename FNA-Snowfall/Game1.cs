using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace FNA_Snowfall
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Texture2D snowflakeTexture;
        private List<Snowflake> snowflakes;
        private Random random = new Random();

        private int windowHeight = 600;
        private int windowWidth = 800;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = windowHeight;
            graphics.PreferredBackBufferWidth = windowWidth;
            graphics.IsFullScreen = false;
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

            for (int i = 0; i < 100; i++)
            {
                float size = (float)random.NextDouble() * 0.05f;
                float speed = (float)random.NextDouble() * 50f + 30f;
                Vector2 startPosition = new Vector2(random.Next(0, 800), random.Next(0, 480));

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
                if (snowflake.Position.Y > windowHeight)
                {
                    snowflake.Position.Y = -20;
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
