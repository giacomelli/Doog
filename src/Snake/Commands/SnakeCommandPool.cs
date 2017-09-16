namespace Snake.Commands
{
    public static class SnakeCommandPool
    {
        public static MoveDownCommand MoveDown = new MoveDownCommand();

        public static MoveUpCommand MoveUp = new MoveUpCommand();

        public static MoveLeftCommand MoveLeft = new MoveLeftCommand();

        public static MoveRightCommand MoveRight = new MoveRightCommand();
    }
}
