﻿using Doog;

namespace Snake.Commands
{
    public class MoveUpCommand : CommandBase<Snake>
    {
        protected override void Execute(Snake target)
        {
            target.MoveUp();
        }

        public static MoveUpCommand Default => new MoveUpCommand();
    }
}
