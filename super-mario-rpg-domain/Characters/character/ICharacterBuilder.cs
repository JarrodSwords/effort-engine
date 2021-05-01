using Effort.Domain;
using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Domain.Characters
{
    public interface ICharacterBuilder
    {
        CharacterTypes GetCharacterTypes();
        Id GetId();
        Name GetName();
    }
}
