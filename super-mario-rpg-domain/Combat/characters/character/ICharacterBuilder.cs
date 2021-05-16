using Effort.Domain;
using SuperMarioRpg.Domain.Old.Combat;

namespace SuperMarioRpg.Domain.Combat
{
    public interface ICharacterBuilder
    {
        CharacterTypes GetCharacterTypes();
        Id GetId();
        Name GetName();
    }
}
