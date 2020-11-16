using System;

namespace SuperMarioRpg.Domain.Combat
{
    public interface ICharacterBuilder
    {
        CharacterTypes CharacterType { get; }
        Guid Id { get; }
        Loadout Loadout { get; }
        Stats NaturalStats { get; }
        ProgressionSystem ProgressionSystem { get; }

        void CreateLoadout();
        void CreateNaturalStats();
        void CreateProgressionSystem();
    }
}
