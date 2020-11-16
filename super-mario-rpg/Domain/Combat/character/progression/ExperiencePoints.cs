using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class ExperiencePoints : TinyType<ushort>
    {
        #region Core

        public ExperiencePoints(ushort value = 0) : base(value)
        {
        }

        #endregion

        #region Equality, Operators

        public static ExperiencePoints operator +(ExperiencePoints left, ExperiencePoints right) =>
            new ExperiencePoints((ushort) (left.Value + right.Value));

        #endregion
    }
}
