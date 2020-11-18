using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Level : TinyType<byte>
    {
        #region Core

        private Level(byte value) : base(value)
        {
        }

        #endregion

        #region Public Interface

        public static Level CreateLevel(byte value = default) => new Level(value);

        #endregion

        #region Equality, Operators

        public static Level operator +(Level left, Level right) => CreateLevel((byte) (left.Value + right.Value));

        #endregion
    }
}
