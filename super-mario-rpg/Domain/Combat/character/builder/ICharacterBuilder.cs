using System;

namespace SuperMarioRpg.Domain.Combat
{
    public interface ICharacterBuilder
    {
        CharacterTypes CharacterType { get; }
        ExperiencePoints ExperiencePoints { get; }
        Guid Id { get; }
        Level Level { get; }
        Loadout Loadout { get; }
        Stats NaturalStats { get; }

        void CreateLoadout();
        void CreateNaturalStats();
    }
}
