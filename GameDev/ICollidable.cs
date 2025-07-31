using Microsoft.Xna.Framework;

namespace GameDev
{
    public interface ICollidable
    {
        Rectangle BoundingBox { get; }
    }
}
