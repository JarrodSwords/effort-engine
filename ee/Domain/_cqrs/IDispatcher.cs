namespace Effort.Domain
{
    public interface IDispatcher
    {
        #region Public Interface

        T Dispatch<T>(ICommand command);
        T Dispatch<T>(IQuery<T> query);

        #endregion
    }
}
