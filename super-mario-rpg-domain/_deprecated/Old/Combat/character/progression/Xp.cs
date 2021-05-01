using Effort.Domain;

namespace SuperMarioRpg.Domain.Old.Combat
{
    public class Xp : TinyType<ushort>
    {
        #region Creation

        public Xp(ushort value = default) : base(value)
        {
        }

        #endregion

        #region Static Interface

        public static Xp operator +(Xp left, Xp right) => new((ushort) (left.Value + right.Value));
        public static Xp operator -(Xp left, Xp right) => new((ushort) (left.Value - right.Value));
        public static implicit operator Xp(ushort value) => new(value);

        #endregion
    }
}
