using System.Collections.Generic;
using Effort.Domain.Messages;

namespace SuperMarioRpg.Application.Read
{
    public record FetchCharacters : IQuery<IEnumerable<Character>>;

    public record FindCharacter(string Name) : IQuery<Character>;

    public record Character(string Name);
}
