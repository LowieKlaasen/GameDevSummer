using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GameDev
{
    internal class Hero : IGameObject
    {
        private Texture2D texture;
        Animation animation;

        public Hero(Texture2D texture)
        {

            this.texture = texture;
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 4, 2);
        }

        public void draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, new Vector2(0, 0), animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }
    }
}
