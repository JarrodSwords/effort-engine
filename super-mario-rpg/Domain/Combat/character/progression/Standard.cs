namespace SuperMarioRpg.Domain.Combat
{
    public class Standard : ProgressionSystem
    {
        #region Creation

        public Standard(Character character, Xp xp) : base(character, xp)
        {
        }

        #endregion

        #region Public Interface

        public override ProgressionSystem Add(Xp xp)
        {
            var newXp = Xp + xp;
            LevelUp(newXp);
            return new Standard(Character, newXp);
        }

        #endregion
    }
}