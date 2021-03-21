using System.Collections.Generic;

namespace SuperMarioRpg.Application
{
    public interface ICharacterService
    {
        #region Public Interface

        IEnumerable<CharacterDto> Fetch();
        CharacterDto Fetch(string recordName);

        #endregion
    }
}
