using Effort.Domain;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application
{
    public record FindCharacter(string Name) : IQuery<CharacterDto>
    {
        #region Nested Types

        public class FetchCharacterHandler : IQueryHandler<FindCharacter, CharacterDto>
        {
            #region IQueryHandler<FindCharacter,CharacterDto> Implementation

            public CharacterDto Handle(FindCharacter query) => new();

            #endregion
        }

        #endregion
    }
}
