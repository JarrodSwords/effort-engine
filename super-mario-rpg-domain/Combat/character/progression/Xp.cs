using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public class Xp : TinyType<ushort>
    {
        #region Creation

        public Xp(ushort value = default) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static Xp operator +(Xp left, Xp right)
        {
            return new((ushort) (left.Value + right.Value));
        }

        public static implicit operator Xp(ushort value)
        {
            return new(value);
        }

        public static Xp operator -(Xp left, Xp right)
        {
            return new((ushort) (left.Value - right.Value));
        }

        #endregion
    }
}
