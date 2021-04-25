namespace SuperMarioRpg.Domain
{
    public interface INonPlayableCharacterRepository : IRepository<NonPlayableCharacter>
    {
        #region Public Interface

        string Create(NonPlayableCharacter nonPlayableCharacter);
        void Create(params NonPlayableCharacter[] nonPlayerCharacters);

        #endregion
    }
}
