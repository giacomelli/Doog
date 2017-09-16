namespace Doog.Framework.Behaviors.Commands
{
    public abstract class CommandBase<TTarget> : ICommand
    {
        public void Execute(object target)
        {
            Execute((TTarget)target);
        }

        protected abstract void Execute(TTarget target);
    }
}
