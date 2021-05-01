namespace SuperMarioRpg.Domain.Combat
{
    public static class EnumExtensions
    {
        #region Static Interface

        public static bool Contains(this Buffs target, Buffs other) => (target & other) > 0;
        public static bool Contains(this CharacterTypes target, CharacterTypes other) => (target & other) > 0;

        #endregion
    }
}
