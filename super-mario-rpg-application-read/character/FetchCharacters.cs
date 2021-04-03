using System.Collections.Generic;
using Effort.Domain.Messages;
using SuperMarioRpg.Api;

namespace SuperMarioRpg.Application.Read
{
    public record FetchCharacters : IQuery<IEnumerable<CharacterDto>>
    {
        #region Nested Types

        internal class Handler : IQueryHandler<FetchCharacters, IEnumerable<CharacterDto>>
        {
            #region IQueryHandler<FetchCharacters,IEnumerable<CharacterDto>> Implementation

            public IEnumerable<CharacterDto> Handle(FetchCharacters query)
            {
                return new List<CharacterDto>();
            }

            #endregion
        }

        #endregion
    }
}
