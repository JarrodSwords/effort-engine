namespace SuperMarioRpg.Domain.Combat
{
    public class Director
    {
        #region Public Interface

        public void Configure(ICharacterBuilder builder)
        {
            builder.CreateLoadout();
            builder.CreateNaturalStats();
        }

        #endregion
    }
}
