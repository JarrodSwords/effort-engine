using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Xp : TinyType<ushort>
    {
        #region Creation

        private Xp(ushort value) : base(value)
        {
        }

        public static Xp CreateXp(ushort value = default) => new Xp(value);

        #endregion

        #region Equality, Operators

        public static Xp operator +(Xp left, Xp right) => CreateXp((ushort) (left.Value + right.Value));
        public static Xp operator -(Xp left, Xp right) => CreateXp((ushort) (left.Value - right.Value));

        #endregion
    }
}
