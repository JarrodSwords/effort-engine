using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class LevelReward : ValueObject<LevelReward>
    {
        #region Core

        public LevelReward(byte level, ushort xp, Stats stats)
        {
            Level = Level.Create(level);
            Required = Xp.Create(xp);
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
