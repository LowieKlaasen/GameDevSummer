namespace GameDev
{
    internal class MovementManager
    {
        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();
            
            // Check if the input is destinational using a custom property or method
            if (movable.InputReader is IDestinationalInputReader destinationalInputReader && destinationalInputReader.IsDestinationalInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            var distance = direction * movable.Speed;
            var futurePosition = movable.Position + distance;

            if (futurePosition.X < (800 - 160) && futurePosition.X > 160)
            {
                movable.Position = futurePosition;
            }

            if (futurePosition.X < (800 - 128) && futurePosition.X > 0 && futurePosition.Y < (480 - 128) && futurePosition.Y > 0)
            {
                //movable.Position = futurePosition;
                movable.Position += distance;
            }

            //movable.Position = futurePosition;
            //movable.Position += distance;
        }
    }

    // Add this interface to define the IsDestinationalInput property
    internal interface IDestinationalInputReader : IInputReader
    {
        bool IsDestinationalInput { get; }
    }
}
