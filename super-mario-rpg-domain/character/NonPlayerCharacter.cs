namespace SuperMarioRpg.Domain
{
    public class NonPlayerCharacter : Character
    {
        #region Creation

        public NonPlayerCharacter(ICharacterBuilder builder) : base(builder)
        {
        }

        #endregion

        #region Nested Types

        public new interface IRepository : IRepository<NonPlayerCharacter>
        {
        }

        #endregion
    }
}
