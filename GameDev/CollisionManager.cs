using Microsoft.Xna.Framework;

namespace GameDev
{
    public class CollisionManager
    {
        public bool WillIntersect(ICollidable moving, Vector2 futurePosition, ICollidable obstacle)
        {
            var futureBoundingBox = new Rectangle(
                (int)futurePosition.X,
                (int)futurePosition.Y,
                moving.BoundingBox.Width,
                moving.BoundingBox.Height
            );
            return futureBoundingBox.Intersects(obstacle.BoundingBox);
        }
    }
}
