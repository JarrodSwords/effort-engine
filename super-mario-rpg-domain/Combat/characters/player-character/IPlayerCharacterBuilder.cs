using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public interface IPlayerCharacterBuilder
    {
        Id GetId();
        PlayableCharacter GetPlayableCharacter();
    }
}
