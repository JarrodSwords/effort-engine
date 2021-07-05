using Effort.Domain.Messages;

namespace SuperMarioRpg.Application.Read
{
    public record FindPlayer(string UserName) : IQuery<Player>;

    public record Player(
        string EmailAddress,
        string UserName
    );
}
