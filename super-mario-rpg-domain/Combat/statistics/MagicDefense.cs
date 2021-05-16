using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class MagicDefense : TinyType<short>
    {
        #region Creation

        public MagicDefense(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator MagicDefense(short value) => new(value);

        #endregion
    }
}
