namespace Snake.Framework.Input
{
    public interface IInputSystem
    {
        bool IsKeyDown(Keys key);

        void Update();
    }
}
