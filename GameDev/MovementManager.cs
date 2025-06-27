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
            movable.Position += distance;
        }
    }

    // Add this interface to define the IsDestinationalInput property
    internal interface IDestinationalInputReader : IInputReader
    {
        bool IsDestinationalInput { get; }
    }
}
