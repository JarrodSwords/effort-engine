using System;
using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class ProgressionSystem : ValueObject<ProgressionSystem>
    {
        #region Core

        public ProgressionSystem(
            Level level,
            ExperiencePoints experiencePoints
        )
        {
            Level = level;
            ExperiencePoints = experiencePoints;
        }

        #endregion

        #region Public Interface

        public ExperiencePoints ExperiencePoints { get; }
        public Level Level { get; }

        public List<LevelReward> LevelRewards =>
            new List<LevelReward>
            {
                new LevelReward(1, 0),
                new LevelReward(2, 16),
                new LevelReward(3, 48)
            };

        public ProgressionSystem Add(ExperiencePoints experiencePoints)
        {
            var newExperiencePoints = ExperiencePoints + experiencePoints;
            var newLevel = LevelRewards.FindLast(x => x.Required.Value <= newExperiencePoints.Value).Level;

            return new ProgressionSystem(newLevel, newExperiencePoints);
        }
        
        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(ProgressionSystem other) =>
            Level == other.Level && ExperiencePoints == other.ExperiencePoints;

        protected override int GetHashCodeExplicit() => (ExperiencePoints, Level).GetHashCode();

        #endregion
    }

    public class LevelReward : ValueObject<LevelReward>
    {
        #region Core

        public LevelReward(byte level, ushort experiencePoints)
        {
            Level = new Level(level);
            Required = new ExperiencePoints(experiencePoints);
        }

        #endregion

        #region Public Interface

        public Level Level { get; }
        public ExperiencePoints Required { get; }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(LevelReward other) => Level == other.Level && Required == other.Required;
        protected override int GetHashCodeExplicit() => throw new NotImplementedException();

        #endregion
    }
}
