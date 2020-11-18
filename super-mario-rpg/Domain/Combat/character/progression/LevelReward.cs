using System;
using Effort.Domain;
using static SuperMarioRpg.Domain.Combat.Level;
using static SuperMarioRpg.Domain.Combat.Xp;

namespace SuperMarioRpg.Domain.Combat
{
    public class LevelReward : ValueObject<LevelReward>
    {
        #region Core

        public LevelReward(byte level, ushort xp, Stats stats)
        {
            Level = CreateLevel(level);
            Required = CreateXp(xp);
            Stats = stats;
        }

        #endregion

        #region Public Interface

        public Level Level { get; }
        public Xp Required { get; }
        public Stats Stats { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(LevelReward other) => Level == other.Level && Required == other.Required;
        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
