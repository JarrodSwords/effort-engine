using System;

namespace SuperMarioRpg.Domain.Combat
{
    public interface ICharacterBuilder
    {
        #region Public Interface

        Equipment Accessory { get; }
        Equipment Armor { get; }
        CharacterTypes CharacterType { get; }
        Guid Id { get; }
        Stats NaturalStats { get; }
        Equipment Weapon { get; }
        Xp Xp { get; }

        void CreateLoadout();
        void CreateNaturalStats();

        #endregion
    }
}
