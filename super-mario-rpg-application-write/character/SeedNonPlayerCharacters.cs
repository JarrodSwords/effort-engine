using System.Linq;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write
{
    public record SeedNonPlayerCharacters : ICommand
    {
        #region Nested Types

        internal class Handler : Handler<SeedNonPlayerCharacters>
        {
            private static readonly CreateNonPlayerCharacter[] Characters =
            {
                new("Boshi"),
                new("Frogfucious"),
                new("Chancellor"),
                new("Toad"),
                new("Toadofsky")
            };

            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(SeedNonPlayerCharacters command)
            {
                var characters = Characters.Select(CreateNonPlayerCharacter.Build);

                UnitOfWork.NonPlayerCharacters.Create(characters.ToArray());

                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
