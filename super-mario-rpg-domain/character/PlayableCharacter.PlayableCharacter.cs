namespace SuperMarioRpg.Domain
{
    public partial class PlayableCharacter
    {
        #region Nested Types

        public new interface IRepository : IRepository<PlayableCharacter>
        {
            #region Public Interface

            string Create(PlayableCharacter playableCharacter);
            void Create(params PlayableCharacter[] playableCharacters);

            #endregion
        }

        #endregion
    }
}
