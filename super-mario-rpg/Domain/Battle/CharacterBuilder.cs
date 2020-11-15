namespace SuperMarioRpg.Domain.Battle
{
    public class CharacterBuilder : ICharacterBuilder
    {
        #region Core

        private readonly CharacterType _mario;

        public CharacterBuilder(CharacterType mario)
        {
            _mario = mario;
        }

        #endregion

        #region Public Interface

        public Loadout Loadout { get; private set; }
        public Stats Stats { get; private set; }

        public Character Build() => new Character(this);

        public CharacterBuilder WithEquipment(Equipment armor)
        {
            Armor = armor;
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
            Stats = new Stats(20, 0, 20, 10, 2, 20);
        }

        #endregion
    }
}
