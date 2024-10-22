using Microsoft.Xna.Framework;

namespace FNA_Snowfall
{
    internal class Snowflake
    {
        /// <summary>
        /// Расположение
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// Размер
        /// </summary>
        public float Size { get; }

        private readonly float speed;

        public Snowflake(Vector2 startPosition, float speed, float size)
        {
            Position = startPosition;
            this.speed = speed;
            Size = size;
        }

        /// <summary>
        /// Перемещает <see cref="Snowflake"/> вниз на заданное число <see cref="Snowflake.speed"/>
        /// </summary>
        public void Fall(GameTime gameTime)
        {
            Position = new Vector2(Position.X, Position.Y + speed * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
