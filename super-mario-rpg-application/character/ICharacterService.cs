using System.Collections.Generic;
using Effort.Domain;
using SuperMarioRpg.Domain;

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
