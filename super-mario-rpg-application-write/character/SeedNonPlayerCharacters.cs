using System.Linq;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write
{
    public record SeedNonPlayerCharacters : ICommand
    {
        #region Nested Types

        internal class Handler : Handler<SeedNonPlayerCharacters>
        {
            private readonly NonPlayerCharacterBuilder _builder = new();

            private static readonly CreateNonPlayerCharacterArgs[] Characters =
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
                var characters = Characters.Select(x => _builder.From(x).Build()).ToArray();

                UnitOfWork.NonPlayerCharacterRepository.Create(characters);

                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
