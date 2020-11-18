using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Level : TinyType<byte>
    {
        #region Core

        public Level(byte value = 0) : base(value)
        {
        }

        #endregion

        #region Equality, Operators

        public static Level operator +(Level left, Level right) => new Level((byte) (left.Value + right.Value));

        #endregion
    }
}
