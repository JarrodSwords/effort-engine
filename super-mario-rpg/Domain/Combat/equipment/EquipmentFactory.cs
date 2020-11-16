using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Combat
{
    public class EquipmentFactory
    {
        #region Singleton

        public static EquipmentFactory Instance => new EquipmentFactory();

        #endregion

        #region Core

        private readonly IDictionary<EquipmentType, Equipment> _equipment;

        private EquipmentFactory()
        {
            _equipment = new Dictionary<EquipmentType, Equipment>();
            Initialize();
        }

        #endregion

        #region Public Interface

        public Equipment Create(EquipmentType equipmentType) => _equipment[equipmentType].Clone();

        #endregion

        #region Private Interface

        private void Initialize()
        {
            _equipment.Add(
                EquipmentType.Hammer,
                new Equipment("Hammer", EquipmentType.Hammer, Slot.Weapon, Characters.Mario)
            );
            _equipment.Add(
                EquipmentType.JumpShoes,
                new Equipment("Jump Shoes", EquipmentType.JumpShoes, Slot.Accessory, Characters.Mario)
            );
            _equipment.Add(
                EquipmentType.Shirt,
                new Equipment("Shirt", EquipmentType.Shirt, Slot.Armor, Characters.Mario)
            );
        }

        #endregion
    }
}
