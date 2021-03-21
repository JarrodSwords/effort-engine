namespace SuperMarioRpg.Domain
{
    public class CreateCharacterCommand : ICommand
    {
        #region Creation

        public CreateCharacterCommand(string name)
        {
            Name = name;
        }

        #endregion

        #region Public Interface

        public string Name { get; set; }

        #endregion
    }
}
