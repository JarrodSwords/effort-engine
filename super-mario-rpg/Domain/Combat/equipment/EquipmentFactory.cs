using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarioRpg.Domain.Combat
{
    public class EquipmentFactory
    {
        public static Equipment ExpBooster = CreateEquipment(EquipmentType.ExpBooster);
        public static Equipment Hammer = CreateEquipment(EquipmentType.Hammer);
        public static Equipment JumpShoes = CreateEquipment(EquipmentType.JumpShoes);
        public static Equipment PolkaDress = CreateEquipment(EquipmentType.PolkaDress);
        public static Equipment Shirt = CreateEquipment(EquipmentType.Shirt);
        public static Equipment SlapGlove = CreateEquipment(EquipmentType.SlapGlove);

        #region Creation

        public static Equipment CreateEquipment(EquipmentType equipmentType)
        {
            var equipment = equipmentType switch
            {
                EquipmentType.ExpBooster => Equipment.CreateEquipment(
                    equipmentType,
                    EquipmentSlot.Accessory,
                    CharacterTypes.All,
                    "Exp. Booster",
                    Buffs.DoubleXp
                ),
                EquipmentType.Hammer => Equipment.CreateEquipment(
                    equipmentType,
                    EquipmentSlot.Weapon,
                    CharacterTypes.Mario,
                    "Hammer"
                ),
                EquipmentType.JumpShoes => Equipment.CreateEquipment(
                    equipmentType,
                    EquipmentSlot.Accessory,
                    CharacterTypes.Mario,
                    "Jump Shoes"
                ),
                EquipmentType.PolkaDress => Equipment.CreateEquipment(
                    equipmentType,
                    EquipmentSlot.Armor,
                    CharacterTypes.Toadstool,
                    "Polka Dress"
                ),
                EquipmentType.Shirt => Equipment.CreateEquipment(
                    equipmentType,
                    EquipmentSlot.Armor,
                    CharacterTypes.Mario,
                    "Shirt"
                ),
                EquipmentType.SlapGlove => Equipment.CreateEquipment(
                    equipmentType,
                    EquipmentSlot.Weapon,
                    CharacterTypes.Toadstool,
                    "Slap Glove"
                ),
                _ => throw new ArgumentOutOfRangeException(nameof(equipmentType), equipmentType, null)
            };

            return equipment;
        }

        public static IEnumerable<Equipment> CreateEquipment(params EquipmentType[] equipmentTypes) =>
            equipmentTypes.Select(CreateEquipment);

        #endregion
    }
}
