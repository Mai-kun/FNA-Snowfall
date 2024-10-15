using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FNA_Snowfall
{
    internal class Snowflake
    {
        public Vector2 Position;
        public float Speed;
        public float Size;
        public Texture2D Texture;

        public Snowflake(Texture2D texture, Vector2 startPosition, float speed, float size)
        {
            Texture = texture;
            Position = startPosition;
            Speed = speed;
            Size = size;
        }

        public void Fall(GameTime gameTime)
        {
            Position.Y += Speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0f, Vector2.Zero, Size, SpriteEffects.None, 0f);
        }
    }
}
