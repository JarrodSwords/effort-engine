using Effort.Domain.Messages;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write
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
