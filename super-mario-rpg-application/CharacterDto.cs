using System.Collections.Generic;

namespace SuperMarioRpg.Application
{
    public class CharacterDto
    {
    }

    public interface ICharacterService
    {
        #region Public Interface

        IEnumerable<CharacterDto> Fetch();

        #endregion
    }

    public class BasicCharacterService : ICharacterService
    {
        #region ICharacterService Implementation

        public IEnumerable<CharacterDto> Fetch() => new List<CharacterDto> { new() };

        #endregion
    }
}
