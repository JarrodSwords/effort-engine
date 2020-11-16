using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarioRpg.Domain.Combat
{
    public class EquipmentFactory
    {
        #region Core

        public static Equipment Hammer = CreateEquipment(EquipmentType.Hammer);
        public static Equipment JumpShoes = CreateEquipment(EquipmentType.JumpShoes);
        public static Equipment Shirt = CreateEquipment(EquipmentType.Shirt);

        #endregion

        #region Public Interface

        public static Equipment CreateEquipment(EquipmentType equipmentType)
        {
            var equipment = equipmentType switch
            {
                EquipmentType.Hammer => new Equipment("Hammer", EquipmentType.Hammer, Slot.Weapon, CharacterTypes.Mario),
                EquipmentType.JumpShoes => new Equipment(
                    "Jump Shoes",
                    EquipmentType.JumpShoes,
                    Slot.Accessory,
                    CharacterTypes.Mario
                ),
                EquipmentType.Shirt => new Equipment("Shirt", EquipmentType.Shirt, Slot.Armor, CharacterTypes.Mario),
                _ => throw new ArgumentOutOfRangeException(nameof(equipmentType), equipmentType, null)
            };

            return equipment;
        }

        public static IEnumerable<Equipment> CreateEquipment(params EquipmentType[] equipmentTypes) =>
            equipmentTypes.Select(CreateEquipment);

        #endregion
    }
}
