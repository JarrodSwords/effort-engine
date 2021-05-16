using Effort.Domain;
using SuperMarioRpg.Domain.Old.Combat;

namespace SuperMarioRpg.Domain.Overworld
{
    public interface ICharacterBuilder
    {
        CharacterTypes GetCharacterTypes();
        Id GetId();
        Name GetName();
    }
}
