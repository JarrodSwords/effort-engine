using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarioRpg.Domain.Battle
{
    public class CharacterBuilder : CharacterBuilderBase, ICharacterBuilder
    {
        #region Core

        private readonly List<Equipment> _equipment;

        public CharacterBuilder(Characters characterType) : base(characterType)
        {
            _equipment = new List<Equipment>();
        }

        #endregion

        #region Public Interface

        public CharacterBuilder WithEquipment(params Equipment[] equipment)
        {
            _equipment.AddRange(equipment);
            return this;
        }

        public CharacterBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        #endregion

        #region Private Interface

        private void ValidateEquipment()
        {
            var equipmentBySlot = from e in _equipment
                                  group e by e.Slot
                                  into g
                                  select new
                                  {
                                      Equipment = g.Key,
                                      Count = g.Count()
                                  };

            if (equipmentBySlot.Any(x => x.Count > 1))
                throw new ArgumentException(
                    $"Invalid {nameof(Loadout)}. Cannot have more than one item per slot.",
                    nameof(_equipment)
                );
        }

        #endregion

        #region ICharacterBuilder

        public void CreateLoadout()
        {
            ValidateEquipment();

            Loadout = new Loadout(
                _equipment.FirstOrDefault(x => x.Slot == Slot.Accessory),
                _equipment.FirstOrDefault(x => x.Slot == Slot.Armor),
                _equipment.FirstOrDefault(x => x.Slot == Slot.Weapon)
            );
        }

        #endregion
    }
}
