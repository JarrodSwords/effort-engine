using System;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application.Write
{
    public record CreateEnemy(
        string Name,
        ushort HitPoints,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense,
        decimal Evade,
        decimal MagicEvade,
        short Speed
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
                var (_, hitPoints, attack, magicAttack, defense, magicDefense, evade, magicEvade, speed) = _command;

                return new CombatStats(
                    hitPoints,
                    attack,
                    magicAttack,
                    defense,
                    magicDefense,
                    evade,
                    magicEvade,
                    speed
                );
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
