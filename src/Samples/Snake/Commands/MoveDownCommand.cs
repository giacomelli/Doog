using Doog;

namespace Snake.Commands
{
    public class MoveDownCommand : CommandBase<Snake>
    {
        protected override void Execute(Snake target)
        {
            target.MoveDown();
        }

        public static MoveDownCommand Default => new MoveDownCommand();
    }
}
