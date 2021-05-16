using System.Linq;
using Effort.Domain.Messages;
using SuperMarioRpg.Application.Write.Characters.NonPlayable;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Overworld;

namespace SuperMarioRpg.Application.Write.Administration
{
    public record SeedNonPlayableCharacters : ICommand
    {
        internal class Handler : Handler<SeedNonPlayableCharacters>
        {
            private static readonly Create[] Characters =
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

            public override void Handle(SeedNonPlayableCharacters command)
            {
                var characters = Characters.Select(x => new NonPlayableCharacter(x));
                UnitOfWork.NonPlayerCharacterRepository.Create(characters.ToArray());
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
