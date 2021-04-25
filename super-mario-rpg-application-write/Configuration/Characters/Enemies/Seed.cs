using System.Linq;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write.Configuration.Characters.Enemies
{
    public record Seed : ICommand
    {
        internal class Handler : Handler<Seed>
        {
            private static readonly Create[] Enemies =
            {
                new("Terrapin", 10, 100, 10, 1, 0, 8, 1, 0, 0),
                new("Bowser", 320, 100, 10, 1, 0, 12, 0, 0, 0),
                new("Kinklink", 60, 100, 99, 0, 0, 10, 0, 0, 0),
                new("Goomba", 16, 100, 13, 3, 1, 3, 1, 0, 0),
                new("Sky Troopa", 10, 100, 18, 4, 6, 16, 4, 0.08m, 0)
            };

            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(Seed command)
            {
                var enemies = Enemies.Select(Create.Build);

                UnitOfWork.Enemies.Create(enemies.ToArray());

                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
