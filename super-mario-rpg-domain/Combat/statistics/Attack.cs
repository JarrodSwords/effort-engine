using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Attack : TinyType<short>
    {
        #region Creation

        public Attack(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Attack(short value) => new(value);

        #endregion
    }
}
