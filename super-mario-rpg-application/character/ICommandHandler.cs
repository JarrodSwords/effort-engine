namespace SuperMarioRpg.Application
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        #region Public Interface

        void Handle(T command);

        #endregion
    }
}
