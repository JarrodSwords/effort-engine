using Effort.Domain;

namespace SuperMarioRpg.Domain.Battle
{
    public class Loadout : ValueObject<Loadout>
    {
        #region Core

        public Loadout(Equipment accessory = null, Equipment armor = null, Equipment weapon = null)
        {
            Accessory = accessory ?? Equipment.NullAccessory;
            Armor = armor ?? Equipment.NullArmor;
            Weapon = weapon ?? Equipment.NullWeapon;
        }

        #endregion

        #region Public Interface

        public Equipment Accessory { get; }
        public Equipment Armor { get; }
        public Equipment Weapon { get; }

        public bool IsCompatible(Characters character) =>
            (Accessory.CompatibleCharacters
           & Armor.CompatibleCharacters
           & Weapon.CompatibleCharacters
           & character)
          > 0;

        #endregion

        #region Equality, Operators

        protected override bool EqualsExplicit(Loadout other) =>
            Accessory == other.Accessory
         && Armor == other.Armor
         && Weapon == other.Weapon;

        protected override int GetHashCodeExplicit() => (Accessory, Armor, Weapon).GetHashCode();

        #endregion
    }
}
