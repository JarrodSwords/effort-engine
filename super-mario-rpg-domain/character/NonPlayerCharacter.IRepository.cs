namespace SuperMarioRpg.Domain
{
    public partial class NonPlayerCharacter
    {
        public new interface IRepository : IRepository<NonPlayerCharacter>
        {
            #region Public Interface

            string Create(NonPlayerCharacter nonPlayerCharacter);
            void Create(params NonPlayerCharacter[] nonPlayerCharacters);

            #endregion
        }
    }
}
