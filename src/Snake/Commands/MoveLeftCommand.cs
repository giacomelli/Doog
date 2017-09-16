using Doog.Framework;

namespace Snake.Commands
{
    public class MoveLeftCommand : CommandBase<Snake>
    {
        protected override void Execute(Snake snake)
        {
            snake.MoveLeft();
        }
    }
}
