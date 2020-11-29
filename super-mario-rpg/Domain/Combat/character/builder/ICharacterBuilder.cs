using System;
using Effort.Domain;

namespace SuperMarioRpg.Domain.Combat
{
    public interface ICharacterBuilder
    {
        #region Public Interface

        Equipment Accessory { get; }
        Equipment Armor { get; }
        CharacterTypes CharacterType { get; }
        Guid Id { get; }
        Name Name { get; }
        Stats NaturalStats { get; }
        Equipment Weapon { get; }
        Xp Xp { get; }

        void CreateLoadout();
        void CreateNaturalStats();

        #endregion
    }
}
