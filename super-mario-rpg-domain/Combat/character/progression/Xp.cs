using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public record Xp(ushort Value = default) : TinyType<ushort>(Value)
    {
        #region Equality, Operators

        public static Xp operator +(Xp left, Xp right)
        {
            return new((ushort) (left.Value + right.Value));
        }

        public static Xp operator -(Xp left, Xp right)
        {
            return new((ushort) (left.Value - right.Value));
        }

        #endregion
    }
}
