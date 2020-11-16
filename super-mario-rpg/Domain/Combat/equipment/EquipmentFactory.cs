using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarioRpg.Domain.Combat
{
    public class EquipmentFactory
    {
        #region Core

        public static Equipment Hammer = Create(EquipmentType.Hammer);
        public static Equipment JumpShoes = Create(EquipmentType.JumpShoes);
        public static Equipment Shirt = Create(EquipmentType.Shirt);

        #endregion

        #region Public Interface

        public static Equipment Create(EquipmentType equipmentType)
        {
            var equipment = equipmentType switch
            {
                EquipmentType.Hammer => new Equipment("Hammer", EquipmentType.Hammer, Slot.Weapon, Characters.Mario),
                EquipmentType.JumpShoes => new Equipment(
                    "Jump Shoes",
                    EquipmentType.JumpShoes,
                    Slot.Accessory,
                    Characters.Mario
                ),
                EquipmentType.Shirt => new Equipment("Shirt", EquipmentType.Shirt, Slot.Armor, Characters.Mario),
                _ => throw new ArgumentOutOfRangeException(nameof(equipmentType), equipmentType, null)
            };

            return equipment;
        }

        public static IEnumerable<Equipment> Create(params EquipmentType[] equipmentTypes) =>
            equipmentTypes.Select(Create);

        #endregion
    }
}
