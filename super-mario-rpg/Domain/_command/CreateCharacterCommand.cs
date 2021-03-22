using Effort.Domain;

namespace SuperMarioRpg.Domain
{
    public record CreateCharacterCommand(string Name) : ICommand
    {
    }
}
