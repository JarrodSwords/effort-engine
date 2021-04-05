namespace SuperMarioRpg.Domain
{
    public interface INonPlayerCharacterRepository : IRepository<NonPlayerCharacter>
    {
        #region Public Interface

        void Create(params NonPlayerCharacter[] nonPlayerCharacters);

        #endregion
    }
}
