using Doog.Framework.Behaviors.Commands;

namespace Snake.Game.Commands
{
    public class MoveRightCommand : CommandBase<Snake>
    {
        protected override void Execute(Snake target)
        {
            target.MoveRight();
        }
    }
}
