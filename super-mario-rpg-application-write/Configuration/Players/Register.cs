using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Configuration;

namespace SuperMarioRpg.Application.Write.Configuration.Players
{
    public record Register(
        string EmailAddress,
        string Password,
        string UserName
    ) : ICommand
    {
        internal class Handler : Handler<Register>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(Register command)
            {
                var (emailAddress, password, userName) = command;

                var player = new Player(emailAddress, password, userName);

                UnitOfWork.Players.Create(player);
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
