using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDev
{
    internal class Hero : IGameObject
    {
        private Texture2D texture;
        Animation animation;

        private Vector2 position;
        private Vector2 speed;

        public Hero(Texture2D texture)
        {
            this.texture = texture;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 4, 2);

            position = new Vector2(0,0);
            speed = new Vector2(1, 1);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            Move();
        }

        public void Move()
        {
            position += speed;
            if (position.X > 800 - (texture.Width /2) || position.X < 0)
            {
                speed.X *= -1;
            }
            if (position.Y > 480 - (texture.Height /2) || position.Y < 0)
            {
                speed.Y *= -1;
            }
        }
    }
}
