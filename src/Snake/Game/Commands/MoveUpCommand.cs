using Snake.Framework.Behaviors.Commands;

namespace Snake.Game.Commands
{
    public class MoveUpCommand : CommandBase<Snake>
    {
        public override void Execute(Snake target)
        {
            target.MoveUp();
        }
    }
}
