using System;
using Microsoft.Xna.Framework;

namespace GameDev
{
    internal class MovementManager
    {
        public void Move(IMovable movable)
        {
            var input = movable.InputReader.ReadInput();
            movable.Speed = new Vector2(input.X, movable.Speed.Y);

            float gravity = 0.5f;
            movable.Speed = new Vector2(movable.Speed.X, movable.Speed.Y + gravity);

            var futurePosition = movable.Position + movable.Speed;

            float minX = -20;
            float maxX = 800 - 70;
            float minY = 0;
            float maxY = 480 - 70;

            futurePosition.X = Math.Clamp(futurePosition.X, minX, maxX);
            futurePosition.Y = Math.Clamp(futurePosition.Y, minY, maxY);

            movable.Position = futurePosition;
        }

    }

    internal interface IDestinationalInputReader : IInputReader
    {
        bool IsDestinationalInput { get; }
    }
}
