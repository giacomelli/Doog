using Doog.Framework;

namespace Snake.Commands
{
    public class KeyBinding
    {
        public Keys MoveUp { get; set; }

        public Keys MoveDown { get; set; }

        public Keys MoveLeft { get; set; }

        public Keys MoveRight { get; set; }

        public static KeyBinding Default = new KeyBinding
        {
            MoveDown = Keys.DownArrow,
            MoveLeft = Keys.LeftArrow,
            MoveRight = Keys.RightArrow,
            MoveUp = Keys.UpArrow
        };
    }
}
