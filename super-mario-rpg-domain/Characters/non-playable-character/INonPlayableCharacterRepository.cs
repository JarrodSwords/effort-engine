namespace SuperMarioRpg.Domain.Characters
{
    public interface INonPlayableCharacterRepository : IRepository<NonPlayableCharacter>
    {
        string Create(NonPlayableCharacter nonPlayableCharacter);
        void Create(params NonPlayableCharacter[] nonPlayerCharacters);
    }
}
