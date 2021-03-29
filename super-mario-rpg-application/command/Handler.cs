using Effort.Domain;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application
{
    internal abstract class Handler<T> : ICommandHandler<T> where T : ICommand
    {
        protected readonly IUnitOfWork UnitOfWork;

        #region Creation

        protected Handler(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        #endregion

        #region ICommandHandler<T> Implementation

        public abstract void Handle(T command);

        #endregion
    }
}
