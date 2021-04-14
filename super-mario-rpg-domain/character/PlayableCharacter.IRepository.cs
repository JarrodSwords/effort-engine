namespace SuperMarioRpg.Domain
{
    public partial class PlayableCharacter
    {
        #region Nested Types

        public interface IRepository : IRepository<PlayableCharacter>
        {
            #region Public Interface

            string Create(PlayableCharacter playableCharacter);
            void Create(params PlayableCharacter[] playableCharacters);
            PlayableCharacter Find(string name);
            void Update(PlayableCharacter playableCharacter);

            #endregion
        }

        #endregion
    }
}
