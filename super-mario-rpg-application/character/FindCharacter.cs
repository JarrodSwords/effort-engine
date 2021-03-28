﻿using Effort.Domain;

namespace SuperMarioRpg.Application
{
    public record FindCharacter(string Name) : IQuery<CharacterDto>
    {
        #region Nested Types

        public class FindCharacterHandler : IQueryHandler<FindCharacter, CharacterDto>
        {
            #region IQueryHandler<FindCharacter,CharacterDto> Implementation

            public CharacterDto Handle(FindCharacter query)
            {
                return new();
            }

            #endregion
        }

        #endregion
    }
}
