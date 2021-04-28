using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Wpf.Menus.Status
{
    public class StatsViewModel : ViewModel
    {
        private readonly PlayerCharacter _playerCharacter;

        #region Creation

        public StatsViewModel(PlayerCharacter playerCharacter)
        {
            _playerCharacter = playerCharacter;
        }

        #endregion

        #region Public Interface

        public short EffectiveAttack => _playerCharacter.EffectiveStats.Attack;
        public short EffectiveDefense => _playerCharacter.EffectiveStats.Defense;
        public short EffectiveMagicAttack => _playerCharacter.EffectiveStats.SpecialAttack;
        public short EffectiveMagicDefense => _playerCharacter.EffectiveStats.SpecialDefense;
        public short EffectiveSpeed => _playerCharacter.EffectiveStats.Speed;
        public short NaturalAttack => _playerCharacter.NaturalStats.Attack;
        public short NaturalDefense => _playerCharacter.NaturalStats.Defense;
        public short NaturalMagicAttack => _playerCharacter.NaturalStats.SpecialAttack;
        public short NaturalMagicDefense => _playerCharacter.NaturalStats.SpecialDefense;
        public short NaturalSpeed => _playerCharacter.NaturalStats.Speed;
        public ushort NextLevelAt => _playerCharacter.Progression.ToNext;
        public ushort Xp => _playerCharacter.Progression.Xp;

        #endregion
    }
}
