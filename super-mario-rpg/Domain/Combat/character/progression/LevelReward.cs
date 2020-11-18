using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class LevelReward : ValueObject<LevelReward>
    {
        #region Core

        public LevelReward(byte level, ushort experiencePoints, Stats stats)
        {
            Level = Level.Create(level);
            Required = ExperiencePoints.Create(experiencePoints);
            Stats = stats;
        }

        #endregion

        #region Public Interface

        public Level Level { get; }
        public ExperiencePoints Required { get; }
        public Stats Stats { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(LevelReward other) => Level == other.Level && Required == other.Required;
        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
