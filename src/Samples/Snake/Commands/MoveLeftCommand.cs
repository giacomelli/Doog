using Doog;

namespace Snake.Commands
{
    public class MoveLeftCommand : CommandBase<Snake>
    {
        protected override void Execute(Snake target)
        {
            target.MoveLeft();
        }

        public static MoveLeftCommand Default => new MoveLeftCommand();
    }
}
