﻿using Doog.Framework;

namespace Snake.Commands
{
    public class MoveRightCommand : CommandBase<Snake>
    {
        protected override void Execute(Snake target)
        {
            target.MoveRight();
        }
    }
}