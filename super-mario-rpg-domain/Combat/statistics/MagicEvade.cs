using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class MagicEvade : TinyType<decimal>
    {
        #region Creation

        public MagicEvade(decimal value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator MagicEvade(decimal value) => new(value);

        #endregion
    }
}
