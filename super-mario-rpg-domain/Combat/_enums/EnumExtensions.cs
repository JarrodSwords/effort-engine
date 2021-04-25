namespace SuperMarioRpg.Domain.Combat
{
    public static class EnumExtensions
    {
        #region Static Interface

        public static bool Contains(this Buffs target, Buffs other)
        {
            return (target & other) > 0;
        }

        public static bool Contains(this CharacterTypes target, CharacterTypes other)
        {
            return (target & other) > 0;
        }

        #endregion
    }
}
