using Doog;

namespace Breakout.Commands
{
    public class KeyBinding
    {
        public Keys MoveLeft { get; set; }

        public Keys MoveRight { get; set; }

        public static KeyBinding Default => new KeyBinding
        {
            MoveLeft = Keys.LeftArrow,
            MoveRight = Keys.RightArrow,
        };
    }
}
