using System.Collections.Generic;

namespace SuperMarioRpg.Application
{
    public class BasicCharacterService : ICharacterService
    {
        #region ICharacterService Implementation

        public IEnumerable<CharacterDto> Fetch() => new List<CharacterDto> { new() };

        #endregion
    }
}
