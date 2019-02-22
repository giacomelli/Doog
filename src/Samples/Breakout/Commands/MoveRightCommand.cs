using Doog;

namespace Breakout.Commands
{
    public class MoveRightCommand : CommandBase<Paddle>
    {
        protected override void Execute(Paddle target)
        {
            target.MoveRight();
        }

        public static MoveRightCommand Default => new MoveRightCommand();
    }
}
