using System.Linq;
using Effort.Domain.Messages;
using SuperMarioRpg.Application.Write.Characters.Playable;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Application.Write.Administration
{
    public record SeedPlayableCharacters : ICommand
    {
        internal class Handler : Handler<SeedPlayableCharacters>
        {
            private static readonly Create[] PlayableCharacters =
            {
                new("Bowser", 80, 15, 85, 52, 20, 30),
                new("Geno", 45, 30, 60, 23, 20, 30),
                new("Mallow", 20, 18, 22, 3, 15, 10),
                new("Mario", 20, 20, 20, 0, 10, 2),
                new("Toadstool", 50, 24, 40, 24, 40, 28)
            };

            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(SeedPlayableCharacters command)
            {
                var characters = PlayableCharacters.Select(x => new PlayableCharacter(x));
                UnitOfWork.PlayableCharacterRepository.Create(characters.ToArray());
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
