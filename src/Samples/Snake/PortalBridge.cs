using Doog;

namespace Snake
{
    public class PortalBridge
    {
         private PortalBridge(Point pointA, Point pointB, char sprite, IWorldContext ctx)
        {
            var portalA = new Portal(pointA, ctx) { Sprite = sprite };
            var portalB = new Portal(pointB, ctx) { Sprite = sprite };

            portalA.SomethingEnteredCallback = portalB.ExitSomething;
            portalB.SomethingEnteredCallback = portalA.ExitSomething;
        }

        public static PortalBridge Create(Point pointA, Point pointB, char sprite, IWorldContext ctx)
        {
            return new PortalBridge(pointA, pointB, sprite, ctx);
        }
    }
}
