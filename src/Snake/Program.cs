﻿using System;
using System.Threading;
using Snake.Game;

namespace Snake
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var fps = 10.0;
            var sleepTime = (int)Math.Round(1000.0 / fps);
            using (var game = new SnakeGame())
            {
                game.Initialize();
                for (;;)
                {
                    game.Update();
                    game.Draw();
                    Thread.Sleep(sleepTime);
                }
            }
        }
    }
}