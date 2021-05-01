namespace SuperMarioRpg.Domain.Old.Combat
{
    public class Director
    {
        #region Public Interface

        public void Configure(IPlayerCharacterBuilder builder)
        {
            builder.CreateLoadout();
            builder.CreateNaturalStats();
        }

        #endregion
    }
}
