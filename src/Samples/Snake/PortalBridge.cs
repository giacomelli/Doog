using Doog;

namespace Snake
{
    public class PortalBridge
    {
         private PortalBridge(Point pointA, Point pointB, Pixel pixel, IWorldContext ctx)
        {
            var portalA = new Portal(pointA, ctx) { Pixel = pixel };
            var portalB = new Portal(pointB, ctx) { Pixel = pixel };

            portalA.SomethingEnteredCallback = portalB.ExitSomething;
            portalB.SomethingEnteredCallback = portalA.ExitSomething;
        }

        public static PortalBridge Create(Point pointA, Point pointB, Pixel pixel, IWorldContext ctx)
        {
            return new PortalBridge(pointA, pointB, pixel, ctx);
        }
    }
}
