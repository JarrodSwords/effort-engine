namespace SuperMarioRpg.Application
{
    public class CreateCharacterCommand : ICommand
    {
        #region Creation

        public CreateCharacterCommand(CharacterInfoDto characterInfoDto)
        {
            Name = characterInfoDto.Name;
        }

        #endregion

        #region Public Interface

        public string Name { get; set; }

        #endregion
    }
}
