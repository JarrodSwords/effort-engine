using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Xp : TinyType<ushort>
    {
        #region Core

        private Xp(ushort value = default) : base(value)
        {
        }

        #endregion

        #region Public Interface

        public static Xp Create(ushort value = 0) => new Xp(value);

        #endregion

        #region Equality, Operators

        public static Xp operator +(Xp left, Xp right) => Create((ushort) (left.Value + right.Value));

        #endregion
    }
}
