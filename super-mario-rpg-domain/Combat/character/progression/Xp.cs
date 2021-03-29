using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public record Xp : TinyType<ushort>
    {
        #region Creation

        private Xp(ushort value) : base(value)
        {
        }

        #endregion

        #region Public Interface

        public static Xp CreateXp(ushort value = default) => new(value);

        #endregion

        #region Equality, Operators

        public static Xp operator +(Xp left, Xp right) => CreateXp((ushort) (left.Value + right.Value));
        public static Xp operator -(Xp left, Xp right) => CreateXp((ushort) (left.Value - right.Value));

        #endregion
    }
}
