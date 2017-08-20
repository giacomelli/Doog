using Snake.Framework.Behaviors.Commands;

namespace Snake.Game.Commands
{
    public class MoveDownCommand : CommandBase<Snake>
    {
        public override void Execute(Snake target)
        {
            target.MoveDown();
        }
    }
}
