namespace Snake.Framework.Behaviors.Commands
{
    public abstract class CommandBase<TTarget> : ICommand
    {
        public void Execute(object target)
        {
            Execute((TTarget)target);
        }

        public abstract void Execute(TTarget target);
    }
}
