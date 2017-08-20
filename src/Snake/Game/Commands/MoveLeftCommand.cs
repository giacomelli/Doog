using Snake.Framework.Behaviors.Commands;

namespace Snake.Game.Commands
{
    public class MoveLeftCommand : CommandBase<Snake>
    {
        public override void Execute(Snake snake)
        {
            snake.MoveLeft();
        }
    }
}
