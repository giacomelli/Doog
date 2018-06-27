using System;
using Doog.Framework;

namespace Doog.Runners.Console
{
    class Program
    {
        static void Main(string[] args)
        { 
            using (var game = GameActivator.CreateInstance(args))
            {
                var gs = new GraphicSystem();
                var ts = new MapTextSystem(game, "Slant");
                var inputSystem = new InputSystem();
                game.Initialize(
                    gs,
                    new PhysicSystem(),
                    ts,
		            inputSystem,
                    () => Environment.Exit(0));

                GameActivator.Config(game, args);

                var secondsPerFrame = 1f / 120;
                var previous = DateTime.Now;
                var lag = 0.0;

                game.Update(previous);

                for (;;)
                {
                    var current = DateTime.Now;
                    var elapsed = current - previous;
                    previous = current;
                    lag += elapsed.TotalSeconds;

                    // game.ProcessInput();

                    while(lag >= secondsPerFrame)
                    {
                        game.Update(current);
                        lag -= secondsPerFrame;
                    }

                    game.Draw();
                }
            }
        }
    }
}
