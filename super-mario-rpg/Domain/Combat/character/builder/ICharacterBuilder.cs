using System;
using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Combat
{
    public interface ICharacterBuilder
    {
        Equipment Accessory { get; }
        Equipment Armor { get; }
        CharacterTypes CharacterType { get; }
        Guid Id { get; }
        ICollection<Level> Levels { get; }
        Stats NaturalStats { get; }
        Equipment Weapon { get; }
        Xp Xp { get; }

        void CreateLoadout();
        void CreateNaturalStats();
    }
}
