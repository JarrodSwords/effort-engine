namespace SuperMarioRpg.Domain.Battle
{
    public class Director
    {
        #region Public Interface

        public void ConfigureCharacter(ICharacterBuilder builder)
        {
            builder.CreateLoadout();
            builder.CreateStats();
        }

        #endregion
    }
}