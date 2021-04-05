using Effort.Domain.Messages;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write
{
    public record SeedNonPlayerCharacters : ICommand
    {
        #region Nested Types

        internal class Handler : Handler<SeedNonPlayerCharacters>
        {
            private static readonly NonPlayerCharacter[] Characters =
            {
                new("Chancellor"),
                new("Toad")
            };

            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(SeedNonPlayerCharacters command)
            {
                UnitOfWork.NonPlayerCharacterRepository.Create(Characters);

                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
