using Doog;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.Run(typeof(SnakeGame).Assembly, args);
        }
    }
}
