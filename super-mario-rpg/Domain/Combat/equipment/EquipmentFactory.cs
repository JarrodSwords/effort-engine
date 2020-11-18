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
        public static Equipment PolkaDress = CreateEquipment(EquipmentType.PolkaDress);
        public static Equipment Shirt = CreateEquipment(EquipmentType.Shirt);
        public static Equipment SlapGlove = CreateEquipment(EquipmentType.SlapGlove);

        #endregion

        #region Public Interface

        public static Equipment CreateEquipment(EquipmentType equipmentType)
        {
            var equipment = equipmentType switch
            {
                EquipmentType.Hammer => new Equipment(
                    "Hammer",
                    EquipmentType.Hammer,
                    Slot.Weapon,
                    CharacterTypes.Mario
                ),
                EquipmentType.JumpShoes => new Equipment(
                    "Jump Shoes",
                    EquipmentType.JumpShoes,
                    Slot.Accessory,
                    CharacterTypes.Mario
                ),
                EquipmentType.PolkaDress => new Equipment(
                    "Polka Dress",
                    EquipmentType.PolkaDress,
                    Slot.Armor,
                    CharacterTypes.Toadstool
                ),
                EquipmentType.Shirt => new Equipment(
                    "Shirt",
                    EquipmentType.Shirt,
                    Slot.Armor,
                    CharacterTypes.Mario
                ),
                EquipmentType.SlapGlove => new Equipment(
                    "Slap Glove",
                    EquipmentType.SlapGlove,
                    Slot.Weapon,
                    CharacterTypes.Toadstool
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
