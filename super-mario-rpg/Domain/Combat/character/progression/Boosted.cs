namespace SuperMarioRpg.Domain.Combat
{
    public class Boosted : Growth
    {
        #region Creation

        public Boosted(IProgressionSystem progressionSystem) : base(progressionSystem)
        {
        }

        #endregion

        #region Public Interface

        public override IProgressionSystem Add(Xp xp) => ProgressionSystem.Create(xp + xp);

        #endregion
    }
}