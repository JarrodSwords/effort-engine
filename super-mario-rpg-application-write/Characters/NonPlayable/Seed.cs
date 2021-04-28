using System.Linq;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write.Characters.NonPlayable
{
    public record Seed : ICommand
    {
        internal class Handler : Handler<Seed>
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

            public override void Handle(Seed command)
            {
                var characters = Characters.Select(Create.Build);
                UnitOfWork.NonPlayerCharacters.Create(characters.ToArray());
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
