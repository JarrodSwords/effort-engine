using System.Collections.Generic;

namespace SuperMarioRpg.Domain.EquipmentManagement
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
            InitializeEquippables();
        }

        #endregion

        #region Public Interface

        public Equipment Create(EquipmentType equipmentType) => _equipment[equipmentType].Clone();

        #endregion

        #region Private Interface

        private void InitializeEquippables()
        {
            _equipment.Add(EquipmentType.Hammer, new Equipment(Slot.Weapon, "Hammer"));
            _equipment.Add(EquipmentType.Shirt, new Equipment(Slot.Armor, "Shirt"));
        }

        #endregion
    }
}
