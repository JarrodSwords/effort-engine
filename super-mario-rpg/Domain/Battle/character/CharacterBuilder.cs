using System;

namespace SuperMarioRpg.Domain.Battle
{
    public class CharacterBuilder : ICharacterBuilder
    {
        #region Core

        private readonly CharacterType _characterType;

        public CharacterBuilder(CharacterType characterType)
        {
            _characterType = characterType;
        }

        #endregion

        #region Public Interface

        public Guid Id { get; private set; }
        public Loadout Loadout { get; private set; }
        public Stats Stats { get; private set; }

        public Character Build() => new Character(this);

        public CharacterBuilder WithEquipment(Equipment armor)
        {
            Armor = armor;
            return this;
        }

        public CharacterBuilder WithId(Guid id)
        {
            Id = id;
            return this;
        }

        #endregion

        #region Private Interface

        private Equipment Armor { get; set; }

        #endregion

        #region ICharacterBuilder

        public void CreateLoadout()
        {
            Loadout = new Loadout(armor: Armor);
        }

        public void CreateStats()
        {
            Stats = StatFactory.Instance.Create(_characterType);
        }

        #endregion
    }
}
