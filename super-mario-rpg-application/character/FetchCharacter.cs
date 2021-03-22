using Effort.Domain;
using SuperMarioRpg.Domain;

namespace SuperMarioRpg.Application
{
    public record FetchCharacter(string Name) : IQuery<CharacterDto>
    {
        #region Nested Types

        public class FetchCharacterHandler : IQueryHandler<FetchCharacter, CharacterDto>
        {
            #region IQueryHandler<FetchCharacter,CharacterDto> Implementation

            public CharacterDto Handle(FetchCharacter query) => new();

            #endregion
        }

        #endregion
    }
}