namespace SuperMarioRpg.Domain.Combat
{
    public abstract class Growth : IGrowth
    {
        protected IProgressionSystem ProgressionSystem;

        #region Creation

        protected Growth(IProgressionSystem progressionSystem)
        {
            ProgressionSystem = progressionSystem;
        }

        #endregion

        #region IGrowth Implementation

        public abstract IProgressionSystem Add(Xp xp);

        #endregion
    }
}