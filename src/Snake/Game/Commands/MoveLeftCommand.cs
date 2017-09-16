using Doog.Framework.Behaviors.Commands;

namespace Snake.Game.Commands
{
    public class MoveLeftCommand : CommandBase<Snake>
    {
        protected override void Execute(Snake snake)
        {
            snake.MoveLeft();
        }
    }
}
