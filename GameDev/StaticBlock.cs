using Microsoft.Xna.Framework;

namespace GameDev
{
    public class StaticBlock : ICollidable
    {
        public Rectangle BoundingBox { get; }

        public StaticBlock(Rectangle rect)
        {
            BoundingBox = rect;
        }
    }
}
