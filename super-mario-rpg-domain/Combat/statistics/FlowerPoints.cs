using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class FlowerPoints : TinyType<byte>
    {
        #region Creation

        public FlowerPoints(byte value) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static implicit operator FlowerPoints(byte value) => new(value);

        #endregion
    }
}
