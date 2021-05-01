using Effort.Domain;

namespace SuperMarioRpg.Domain.Old.Combat
{
    public interface IPlayerCharacterBuilder
    {
        void CreateLoadout();
        void CreateNaturalStats();

        CharacterTypes GetCharacterType();
        Id GetId();
        Loadout GetLoadout();
        Name GetName();
        Stats GetNaturalStats();
        Xp GetXp();
    }
}
