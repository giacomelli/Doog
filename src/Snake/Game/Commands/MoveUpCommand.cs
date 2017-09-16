using Doog.Framework.Behaviors.Commands;

namespace Snake.Game.Commands
{
    public class MoveUpCommand : CommandBase<Snake>
    {
        protected override void Execute(Snake target)
        {
            target.MoveUp();
        }
    }
}
