using Snake.Framework.Behaviors.Commands;

namespace Snake.Game.Commands
{
    public class MoveRightCommand : CommandBase<Snake>
    {
        public override void Execute(Snake target)
        {
            target.MoveRight();
        }
    }
}
