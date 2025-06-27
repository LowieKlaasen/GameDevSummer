using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace GameDev
{
    internal class KeyboardReader : IInputReader
    {
        public Vector2 ReadInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Vector2 direction = Vector2.Zero;

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                direction.X -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                direction.X += 2;
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                direction.Y -= 2;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                direction.Y += 2;
            }

            return direction;
        }
    }
}
