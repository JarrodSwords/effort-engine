using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public class Evade : TinyType<decimal>
    {
        #region Creation

        public Evade(decimal value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Evade(decimal value) => new(value);

        #endregion
    }
}
