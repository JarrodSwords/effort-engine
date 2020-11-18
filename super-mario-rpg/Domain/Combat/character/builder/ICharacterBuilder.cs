using System;

namespace SuperMarioRpg.Domain.Combat
{
    public interface ICharacterBuilder
    {
        CharacterTypes CharacterType { get; }
        Guid Id { get; }
        Level Level { get; }
        Loadout Loadout { get; }
        Stats NaturalStats { get; }
        Xp Xp { get; }

        void CreateLoadout();
        void CreateNaturalStats();
    }
}
