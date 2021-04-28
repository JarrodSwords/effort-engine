using Effort.Domain;

namespace SuperMarioRpg.Domain.Characters
{
    public interface IPlayableCharacterRepository : IRepository<PlayableCharacter>
    {
        #region Public Interface

        string Create(PlayableCharacter playableCharacter);
        void Create(params PlayableCharacter[] playableCharacters);
        PlayableCharacter Find(Name name);
        void Update(PlayableCharacter playableCharacter);

        #endregion
    }
}
