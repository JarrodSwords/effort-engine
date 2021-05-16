using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public class Speed : TinyType<short>
    {
        #region Creation

        public Speed(short value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator Speed(short value) => new(value);

        #endregion
    }
}
