using System;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Application.Write
{
    public record CreateEnemy(
        string Name,
        ushort HitPoints,
        short Attack,
        short Defense,
        short MagicAttack,
        short MagicDefense,
        short Speed,
        decimal Evade,
        decimal MagicEvade
    ) : ICommand
    {
        #region Nested Types

        internal class Builder : ICharacterBuilder
        {
            private CreateEnemy _command;

            #region Public Interface

            public Enemy Build()
            {
                return new(this);
            }

            public Builder From(CreateEnemy command)
            {
                _command = command;
                return this;
            }

            #endregion

            #region ICharacterBuilder Implementation

            public CombatStats GetCombatStats()
            {
                var (_, hitPoints, attack, defense, magicAttack, magicDefense, speed, evade, magicEvade) = _command;

                var value = Stats.CreateStats(
                    attack,
                    defense,
                    (short) hitPoints,
                    magicAttack,
                    magicDefense,
                    speed,
                    evade,
                    magicEvade
                );

                return new CombatStats(stats: value);
            }

            public Guid GetId()
            {
                return Guid.Empty;
            }

            public string GetName()
            {
                return _command.Name;
            }

            #endregion
        }

        internal class Handler : Handler<CreateEnemy>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(CreateEnemy command)
            {
                var character = new Builder().From(command).Build();

                UnitOfWork.EnemyRepository.Create(character);

                UnitOfWork.Commit();
            }

            #endregion
        }

        #endregion
    }
}
