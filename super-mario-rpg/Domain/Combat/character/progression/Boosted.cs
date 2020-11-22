namespace SuperMarioRpg.Domain.Combat
{
    public class Boosted : ProgressionSystem
    {
        #region Creation

        public Boosted(Character character) : base(character)
        {
        }

        public Boosted(Character character, Xp xp) : base(character, xp)
        {
        }

        #endregion

        #region Public Interface

        public override ProgressionSystem Add(Xp xp)
        {
            var newXp = Xp + xp + xp;
            LevelUp(newXp);
            return new Boosted(Character, newXp);
        }

        #endregion
    }
}