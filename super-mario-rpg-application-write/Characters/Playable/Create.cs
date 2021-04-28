using System;
using Effort.Domain;
using Effort.Domain.Messages;
using SuperMarioRpg.Domain;
using SuperMarioRpg.Domain.Characters;
using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Domain.Stats;
using CombatStats = SuperMarioRpg.Domain.Stats.CombatStats;

namespace SuperMarioRpg.Application.Write.Characters.Playable
{
    public record Create(
        string Name,
        ushort HitPoints,
        short Speed,
        short Attack,
        short MagicAttack,
        short Defense,
        short MagicDefense
    ) : ICommand, ICharacterBuilder, ICombatStatsBuilder
    {
        #region Public Interface

        public PlayableCharacter Build()
        {
            return new(this);
        }

        public CombatStats BuildCombatStats()
        {
            return new(this);
        }

        #endregion

        #region ICharacterBuilder Implementation

        public CharacterTypes GetCharacterTypes()
        {
            return CharacterTypes.Combatant | CharacterTypes.Playable;
        }

        public CombatStats GetCombatStats()
        {
            return BuildCombatStats();
        }

        public EnemyCombatStats GetEnemyCombatStats()
        {
            throw new NotSupportedException();
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

        #region Static Interface

        public static PlayableCharacter Build(Create builder)
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
                UnitOfWork.PlayableCharacters.Create(command.Build());
                UnitOfWork.Commit();
            }

            #endregion
        }
    }
}
