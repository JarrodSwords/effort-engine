namespace SuperMarioRpg.Domain.Combat
{
    public class Director
    {
        #region Public Interface

        public void ConfigureExisting(ICharacterBuilder builder)
        {
            builder.CreateLoadout();
            builder.CreateNaturalStats();
        }

        public void ConfigureNew(ICharacterBuilder builder)
        {
            builder.InitializeGrowth();
            builder.CreateNaturalStats();
        }

        #endregion
    }
}
