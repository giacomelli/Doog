namespace Doog.Runners.MonoGameDesktop.Graphics
{
    public class SpriteBufferItem
    {
        public SpriteBufferItem()
        {
        }

        public SpriteBufferItem(float x, float y, char content)
        {
            X = x;
            Y = y;
            Content = content;
        }

        public float X { get; set; }

        public float Y { get; set; }

        public char Content { get; set; }
    }
}
