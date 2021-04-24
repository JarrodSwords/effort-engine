namespace SuperMarioRpg.Domain
{
    public partial class NonPlayableCharacter
    {
        #region Nested Types

        public interface IRepository : IRepository<NonPlayableCharacter>
        {
            #region Public Interface

            string Create(NonPlayableCharacter nonPlayableCharacter);
            void Create(params NonPlayableCharacter[] nonPlayerCharacters);

            #endregion
        }

        #endregion
    }
}
