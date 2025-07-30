using System;

namespace GameDev
{
    internal class MovementManager
    {
        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();

            if (movable.InputReader is IDestinationalInputReader destinationalInputReader && destinationalInputReader.IsDestinationalInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            var distance = direction * movable.Speed;
            var futurePosition = movable.Position + distance;

            float minX = 0;
            float maxX = 800 - 90;
            float minY = 0;
            float maxY = 480 - 90;

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
