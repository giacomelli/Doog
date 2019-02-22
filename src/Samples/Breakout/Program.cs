using Doog;

namespace Breakout
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.Run(typeof(BreakoutGame).Assembly, args);
        }
    }
}
