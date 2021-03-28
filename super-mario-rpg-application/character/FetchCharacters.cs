using System.Collections.Generic;
using Effort.Domain;

namespace SuperMarioRpg.Application
{
    public record FetchCharacters : IQuery<IEnumerable<CharacterDto>>
    {
        #region Nested Types

        public class FetchCharactersHandler : IQueryHandler<FetchCharacters, IEnumerable<CharacterDto>>
        {
            #region IQueryHandler<FetchCharacters,IEnumerable<CharacterDto>> Implementation

            public IEnumerable<CharacterDto> Handle(FetchCharacters query)
            {
                return new List<CharacterDto> { new() };
            }

            #endregion
        }

        #endregion
    }
}
