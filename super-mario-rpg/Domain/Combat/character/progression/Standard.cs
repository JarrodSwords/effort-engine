namespace SuperMarioRpg.Domain.Combat
{
    public class Standard : Growth
    {
        #region Creation

        public Standard(IProgressionSystem progressionSystem) : base(progressionSystem)
        {
        }

        #endregion

        #region Public Interface

        public override IProgressionSystem Add(Xp xp) => ProgressionSystem.Create(xp);

        #endregion
    }
}