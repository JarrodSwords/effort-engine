namespace SuperMarioRpg.Domain
{
    public partial class NonPlayerCharacter : Character
    {
        #region Creation

        public NonPlayerCharacter(ICharacterBuilder builder) : base(builder)
        {
        }

        #endregion
    }
}
