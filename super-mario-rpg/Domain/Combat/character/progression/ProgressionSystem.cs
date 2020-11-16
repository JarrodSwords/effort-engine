using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class ProgressionSystem : ValueObject<ProgressionSystem>
    {
        #region Core

        public ProgressionSystem(Level level, ExperiencePoints experiencePoints)
        {
            Level = level;
            ExperiencePoints = experiencePoints;
        }

        #endregion

        #region Public Interface

        public ExperiencePoints ExperiencePoints { get; }
        public Level Level { get; }

        public ProgressionSystem Add(ExperiencePoints experiencePoints) =>
            new ProgressionSystem(Level, ExperiencePoints + experiencePoints);

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(ProgressionSystem other) =>
            Level == other.Level && ExperiencePoints == other.ExperiencePoints;

        protected override int GetHashCodeExplicit() => (ExperiencePoints, Level).GetHashCode();

        #endregion
    }
}
