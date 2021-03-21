using System.Collections.Generic;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application
{
    public class BasicCharacterService : ICharacterService
    {
        #region ICharacterService Implementation

        public IEnumerable<CharacterDto> Fetch() => new List<CharacterDto> { new() };

        public CharacterDto Fetch(string recordName) => new();

        #endregion

        #region ICommandHandler<CreateCharacterCommand> Implementation

        public void Handle(CreateCharacterCommand command)
        {
        }

        #endregion
    }
}
