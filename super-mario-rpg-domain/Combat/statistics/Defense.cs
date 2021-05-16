using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Defense : TinyType<short>
    {
        #region Creation

        public Defense(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Defense(short value) => new(value);

        #endregion
    }
}
