using Effort.Domain;
using SuperMarioRpg.Domain.Old.Combat;

namespace SuperMarioRpg.Domain.Characters
{
    public interface ICharacterBuilder
    {
        CharacterTypes GetCharacterTypes();
        Id GetId();
        Name GetName();
    }
}
