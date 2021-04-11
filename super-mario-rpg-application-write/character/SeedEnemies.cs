using System.Linq;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write
{
    public record SeedEnemies : ICommand
    {
        #region Nested Types

        internal class Handler : Handler<SeedEnemies>
        {
            private readonly CreateEnemy.Builder _builder = new();

            private static readonly CreateEnemy[] Enemies =
            {
                new("Terrapin", 10, 1, 0, 8, 1, 0, 0, 10),
                new("Bowser", 320, 1, 0, 12, 0, 0, 0, 10),
                new("Kinklink", 60, 0, 0, 10, 0, 0, 0, 99),
                new("Goomba", 16, 3, 1, 3, 1, 0, 0, 13),
                new("Sky Troopa", 10, 4, 6, 16, 4, 0.08m, 0, 18)
            };

            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(SeedEnemies command)
            {
                var enemies = Enemies.Select(x => _builder.From(x).Build());

                UnitOfWork.EnemyRepository.Create(enemies.ToArray());

                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
