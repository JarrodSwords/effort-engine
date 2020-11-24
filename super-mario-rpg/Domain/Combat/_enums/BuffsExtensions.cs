namespace SuperMarioRpg.Domain.Combat
{
    public static class BuffsExtensions
    {
        #region Public Interface

        public static bool Contains(this Buffs target, Buffs other) => (target & other) > 0;

        #endregion
    }
}
