using Effort.Domain.Messages;

namespace SuperMarioRpg.Application.Read
{
    public record FindCharacter(string Name) : IQuery<CharacterDto>
    {
        #region Nested Types

        internal class Handler : IQueryHandler<FindCharacter, CharacterDto>
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
