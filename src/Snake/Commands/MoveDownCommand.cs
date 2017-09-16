using Doog.Framework;

namespace Snake.Commands
{
    public class MoveDownCommand : CommandBase<Snake>
    {
        protected override void Execute(Snake target)
        {
            target.MoveDown();
        }
    }
}
