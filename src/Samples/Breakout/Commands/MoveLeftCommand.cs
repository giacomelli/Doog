using Doog;

namespace Breakout.Commands
{
    public class MoveLeftCommand : CommandBase<Paddle>
    {
        protected override void Execute(Paddle target)
        {
            target.MoveLeft();
        }

        public static MoveLeftCommand Default => new MoveLeftCommand();
    }
}
