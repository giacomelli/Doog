namespace Doog
{
    public class VirtualGraphicSystem : RectangleComponent, IGraphicSystem
    {        
        public VirtualGraphicSystem(Rectangle bounds, IWorldContext context)
            : base (bounds, context)
        {
        }
        public Rectangle Bounds => Transform.BoundingBox;

        public void Draw(float x, float y, Pixel pixel)
        {
            Context.GraphicSystem.Draw(Transform.Position.X + x, Transform.Position.Y + y, pixel);
        }        

        public void Initialize()
        {            
        }

        public void Render()
        {     
            
        }
    }
}
