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

        public short EffectiveAttack => _playerCharacter.EffectiveStats.Attack.Value;
        public short EffectiveDefense => _playerCharacter.EffectiveStats.Defense.Value;
        public short EffectiveMagicAttack => _playerCharacter.EffectiveStats.SpecialAttack.Value;
        public short EffectiveMagicDefense => _playerCharacter.EffectiveStats.SpecialDefense.Value;
        public short EffectiveSpeed => _playerCharacter.EffectiveStats.Speed.Value;
        public short NaturalAttack => _playerCharacter.NaturalStats.Attack.Value;
        public short NaturalDefense => _playerCharacter.NaturalStats.Defense.Value;
        public short NaturalMagicAttack => _playerCharacter.NaturalStats.SpecialAttack.Value;
        public short NaturalMagicDefense => _playerCharacter.NaturalStats.SpecialDefense.Value;
        public short NaturalSpeed => _playerCharacter.NaturalStats.Speed.Value;
        public ushort NextLevelAt => _playerCharacter.Progression.ToNext.Value;
        public ushort Xp => _playerCharacter.Progression.Xp.Value;

        #endregion
    }
}
