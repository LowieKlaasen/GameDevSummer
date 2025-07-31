using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.ComponentModel.DataAnnotations;

namespace GameDev
{
    internal class Hero : IGameObject, IMovable, ICollidable
    {
        private Texture2D texture;
        Animation animation;

        private Vector2 position;
        private Vector2 speed;
        //private Vector2 acceleration;

        private IInputReader inputReader;
        private MovementManager movementManager;

        // Track the current sprite effect (none or flip horizontally)
        private SpriteEffects spriteEffect = SpriteEffects.None;

        private CollisionManager collisionManager = new CollisionManager();

        public Hero(Texture2D texture, IInputReader inputReader)
        {
            this.texture = texture;
            this.inputReader = inputReader;
            movementManager = new MovementManager();
            animation = new Animation();
            animation.GetFramesFromTextureProperties(texture.Width, texture.Height, 4, 2);

            position = new Vector2(0, 0);
            speed = new Vector2(1, 1);
            //accelaration = new Vector2(0.1f, 0.1f);
        }

        // IMovable implementation
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }

        public Vector2 Speed
        {
            get => speed;
            set => speed = value;
        }

        public IInputReader InputReader
        {
            get => inputReader;
            set => inputReader = value;
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle(
                    (int)position.X + 20,
                    (int)position.Y +20,
                    animation.CurrentFrame.SourceRectangle.Width - 40,
                    animation.CurrentFrame.SourceRectangle.Height - 40
                );
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture,
                position,
                animation.CurrentFrame.SourceRectangle,
                Color.White,
                0f,
                Vector2.Zero,
                1f,
                spriteEffect,
                0f
            );
        }

        public void Update(GameTime gameTime)
        {
            Move();

            // Update spriteEffect based on input direction
            var direction = inputReader.ReadInput();
            if (direction.X < 0)
                spriteEffect = SpriteEffects.FlipHorizontally;
            else if (direction.X > 0)
                spriteEffect = SpriteEffects.None;

            animation.Update(gameTime);
        }

        private void Move()
        {
            movementManager.Move(this);
        }

        // Update & Move colliding
        public void Update(GameTime gameTime, ICollidable obstacle = null)
        {
            Move(obstacle);

            var direction = inputReader.ReadInput();
            if (direction.X < 0)
            {
                spriteEffect = SpriteEffects.FlipHorizontally;
            }
            else if (direction.X > 0)
            {
                spriteEffect = SpriteEffects.None;
            }

            animation.Update(gameTime);
        }

        private void Move(ICollidable obstacle = null)
        {
            var direction = inputReader.ReadInput();
            var distance = direction * speed;
            var futurePosition = position + distance;

            float minX = 0;
            float maxX = 800 - 90;
            float minY = 0;
            float maxY = 480 - 90;
            futurePosition.X = Math.Clamp(futurePosition.X, minX, maxX);
            futurePosition.Y = Math.Clamp(futurePosition.Y, minY, maxY);

            // (animation.CurrentFrame != null) to prevent game from crashing on startup
            if (obstacle != null && animation.CurrentFrame != null)
            {
                var futureBoundingBox = new Rectangle(
                    (int)futurePosition.X + 20,    
                    (int)futurePosition.Y + 20,
                    animation.CurrentFrame.SourceRectangle.Width - 40,
                    animation.CurrentFrame.SourceRectangle.Height - 40
                );
                if (futureBoundingBox.Intersects(obstacle.BoundingBox))
                {
                    return;
                }
            }

            position = futurePosition;
        }
    }
}
