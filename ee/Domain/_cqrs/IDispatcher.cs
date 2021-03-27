namespace Effort.Domain
{
    public interface IDispatcher
    {
        #region Public Interface

        void Dispatch(ICommand command);
        T Dispatch<T>(IQuery<T> query);

        #endregion
    }
}
