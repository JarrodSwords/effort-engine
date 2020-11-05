using System.Collections.Generic;

namespace SuperMarioRpg.Domain.EquipmentManagement
{
    public class EquipmentFactory
    {
        #region Singleton

        public static EquipmentFactory Instance => new EquipmentFactory();

        #endregion

        #region Core

        private readonly IDictionary<Equippable, Equipment> _equipment;

        private EquipmentFactory()
        {
            _equipment = new Dictionary<Equippable, Equipment>();
            InitializeEquippables();
        }

        #endregion

        #region Public Interface

        public Equipment Create(Equippable equippable) => _equipment[equippable].Clone();

        #endregion

        #region Private Interface

        private void InitializeEquippables()
        {
            _equipment.Add(Equippable.Hammer, new Equipment(EquipmentType.Weapon, "Hammer"));
            _equipment.Add(Equippable.Shirt, new Equipment(EquipmentType.Armor, "Shirt"));
        }

        #endregion
    }
}
