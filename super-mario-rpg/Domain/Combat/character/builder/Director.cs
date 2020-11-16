namespace SuperMarioRpg.Domain.Combat
{
    public class Director
    {
        #region Public Interface

        public void ConfigureCharacter(ICharacterBuilder builder)
        {
            builder.CreateLoadout();
            builder.CreateNaturalStats();
        }

        #endregion
    }
}
