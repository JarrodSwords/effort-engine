namespace SuperMarioRpg.Domain.Combat
{
    public class Maxed : Progression
    {
        #region Creation

        public Maxed(Character character, Xp xp, Xp toNext) : base(character, xp, toNext)
        {
        }

        #endregion

        #region Public Interface

        public override Progression Add(Xp xp) => Character.Progression;

        #endregion
    }
}
