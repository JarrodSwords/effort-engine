using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class ExperiencePoints : TinyType<ushort>
    {
        #region Core

        private ExperiencePoints(ushort value = default) : base(value)
        {
        }

        #endregion

        #region Public Interface

        public static ExperiencePoints Create(ushort value = 0) => new ExperiencePoints(value);

        #endregion

        #region Equality, Operators

        public static ExperiencePoints operator +(ExperiencePoints left, ExperiencePoints right) =>
            Create((ushort) (left.Value + right.Value));

        #endregion
    }
}
