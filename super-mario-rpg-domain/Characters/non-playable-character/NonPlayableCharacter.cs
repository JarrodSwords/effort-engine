namespace SuperMarioRpg.Domain.Characters
{
    public class NonPlayableCharacter : Character
    {
        #region Creation

        public NonPlayableCharacter(ICharacterBuilder characterBuilder) : base(characterBuilder)
        {
        }

        #endregion
    }
}
