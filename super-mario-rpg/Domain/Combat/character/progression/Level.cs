using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Level : TinyType<byte>
    {
        #region Core

        public Level(byte value) : base(value)
        {
        }

        #endregion
    }
}
