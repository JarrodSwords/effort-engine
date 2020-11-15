using System.Collections.Generic;

namespace SuperMarioRpg.Domain.Battle
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
                new Equipment(Slot.Weapon, "Hammer", StatFactory.Instance.Create(EquipmentType.Hammer))
            );
            _equipment.Add(
                EquipmentType.JumpShoes,
                new Equipment(Slot.Accessory, "Jump Shoes", StatFactory.Instance.Create(EquipmentType.JumpShoes))
            );
            _equipment.Add(
                EquipmentType.Shirt,
                new Equipment(Slot.Armor, "Shirt", StatFactory.Instance.Create(EquipmentType.Shirt))
            );
        }

        #endregion
    }
}
