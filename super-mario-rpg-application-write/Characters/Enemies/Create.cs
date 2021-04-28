using System;
using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Stats;
using CombatStats = SuperMarioRpg.Domain.Stats.CombatStats;

namespace SuperMarioRpg.Application.Write.Characters.Enemies
{
    public record Create(
        string Name,
        ushort HitPoints,
        byte FlowerPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense,
        decimal Evade,
        decimal MagicEvade
    ) : ICommand, ICharacterBuilder, IEnemyCombatStatsBuilder
    {
        #region Public Interface

        public Enemy Build()
        {
            return new(this);
        }

        public EnemyCombatStats BuildEnemyCombatStats()
        {
            return new(this);
        }

        #endregion

        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes()
        {
            return CharacterTypes.Combatant;
        }

        public CombatStats GetCombatStats()
        {
            throw new NotSupportedException();
        }

        public EnemyCombatStats GetEnemyCombatStats()
        {
            return BuildEnemyCombatStats();
        }

        public Id GetId()
        {
            return default;
        }

        public Name GetName()
        {
            return Name;
        }

        #endregion

        #region ICombatStatsBuilder Implementation

        public short GetAttack()
        {
            return Attack;
        }

        public short GetDefense()
        {
            return Defense;
        }

        public ushort GetHitPoints()
        {
            return HitPoints;
        }

        public short GetMagicAttack()
        {
            return MagicAttack;
        }

        public short GetMagicDefense()
        {
            return MagicDefense;
        }

        public short GetSpeed()
        {
            return Speed;
        }

        #endregion

        #region IEnemyCombatStatsBuilder Implementation

        public decimal GetEvade()
        {
            return Evade;
        }

        public byte GetFlowerPoints()
        {
            return FlowerPoints;
        }

        public decimal GetMagicEvade()
        {
            return MagicEvade;
        }

        #endregion

        #region Static Interface

        public static Enemy Build(Create builder)
        {
            return builder.Build();
        }

        #endregion

        internal class Handler : Handler<Create>
        {
            #region Creation

            public Handler(IUnitOfWork unitOfWork) : base(unitOfWork)
            {
            }

            #endregion

            #region Public Interface

            public override void Handle(Create command)
            {
                UnitOfWork.Enemies.Create(command.Build());
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
