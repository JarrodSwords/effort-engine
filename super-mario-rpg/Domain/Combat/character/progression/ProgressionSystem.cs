using System.Collections.Generic;
using System.Linq;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class ProgressionSystem : ValueObject<ProgressionSystem>
    {
        #region Core

        public ProgressionSystem(
            Level level,
            ExperiencePoints experiencePoints,
            Stats naturalStats
        )
        {
            Level = level;
            ExperiencePoints = experiencePoints;
            NaturalStats = naturalStats;
        }

        #endregion

        #region Public Interface

        public ExperiencePoints ExperiencePoints { get; }
        public Level Level { get; }
        public Stats NaturalStats { get; }

        public List<LevelReward> LevelRewards =>
            new List<LevelReward>
            {
                new LevelReward(1, 0, Stats.Default),
                new LevelReward(2, 16, new Stats(3, 2, 5, 2, 2)),
                new LevelReward(3, 48, new Stats(3, 2, 5, 2, 2))
            };

        public ProgressionSystem Add(ExperiencePoints experiencePoints)
        {
            var newExperiencePoints = ExperiencePoints + experiencePoints;
            var newLevel = LevelRewards.FindLast(x => x.Required.Value <= newExperiencePoints.Value).Level;

            var newStats = LevelRewards
                .SkipWhile(x => x.Level.Value <= Level.Value)
                .TakeWhile(x => x.Level.Value <= newLevel.Value)
                .Select(x => x.Stats)
                .Aggregate(NaturalStats, (x, y) => x + y);

            return new ProgressionSystem(newLevel, newExperiencePoints, newStats);
        }

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(ProgressionSystem other) =>
            Level == other.Level && ExperiencePoints == other.ExperiencePoints;

        protected override int GetHashCodeExplicit() => (ExperiencePoints, Level).GetHashCode();

        #endregion
    }
}
