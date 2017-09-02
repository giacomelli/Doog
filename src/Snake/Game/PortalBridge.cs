using Snake.Framework;
using Snake.Framework.Geometry;

namespace Snake.Game
{
    public class PortalBridge
    {
        private readonly Portal portalA;
        private readonly Portal portalB;

        private PortalBridge(Point pointA, Point pointB, char sprite, IWorldContext ctx)
        {
            portalA = new Portal(pointA, ctx) { Sprite = sprite };
            portalB = new Portal(pointB, ctx) { Sprite = sprite };

            portalA.SomethingEnteredCallback = portalB.ExitSomething;
            portalB.SomethingEnteredCallback = portalA.ExitSomething;
        }

        public static PortalBridge Create(Point pointA, Point pointB, char sprite, IWorldContext ctx)
        {
            return new PortalBridge(pointA, pointB, sprite, ctx);
        }
    }
}
