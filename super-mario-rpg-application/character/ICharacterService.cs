using System.Collections.Generic;

namespace SuperMarioRpg.Application
{
    public interface ICharacterService : ICommandHandler<CreateCharacterCommand>
    {
        #region Public Interface

        IEnumerable<CharacterDto> Fetch();
        CharacterDto Fetch(string recordName);

        #endregion
    }
}
