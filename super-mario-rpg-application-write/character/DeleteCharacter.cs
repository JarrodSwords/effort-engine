using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write
{
    public record DeleteCharacter : ICommand
    {
        #region Creation

        public DeleteCharacter(string name)
        {
            Name = new Name(name);
        }

        #endregion

        #region Public Interface

        public Name Name { get; }

        #endregion

        #region Nested Types

        internal class Handler : Handler<DeleteCharacter>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(DeleteCharacter command)
            {
                UnitOfWork.CharacterRepository.Delete(command.Name);

                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
