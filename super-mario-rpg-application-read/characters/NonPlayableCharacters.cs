using System.Collections.Generic;
using Effort.Domain.Messages;

namespace SuperMarioRpg.Application.Read
{
    public record FetchNonPlayableCharacters : IQuery<IEnumerable<NonPlayableCharacter>>;

    public record FindNonPlayableCharacter(string Name) : IQuery<NonPlayableCharacter>;

    public record NonPlayableCharacter(string Name);
}
