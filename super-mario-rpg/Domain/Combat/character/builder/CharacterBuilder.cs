using System;

namespace SuperMarioRpg.Domain.Combat
{
    public class CharacterBuilder : CharacterBuilderBase, ICharacterBuilder
    {
        #region Core

        private Equipment[] _equipment;

        public CharacterBuilder(Characters characterType) : base(characterType)
        {
        }

        #endregion

        #region Public Interface

        public CharacterBuilder WithEquipment(params Equipment[] equipment)
        {
            Equipment = equipment;
            return this;
        }

        public CharacterBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        #endregion

        #region Private Interface

        private Equipment[] Equipment
        {
            get => _equipment ??= new Equipment[0];
            set => _equipment = value;
        }

        #endregion

        #region ICharacterBuilder

        public void CreateLoadout()
        {
            Loadout = new Loadout(Equipment);
        }

        #endregion
    }
}
