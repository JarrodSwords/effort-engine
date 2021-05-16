using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class MagicAttack : TinyType<short>
    {
        #region Creation

        public MagicAttack(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator MagicAttack(short value) => new(value);

        #endregion
    }
}
