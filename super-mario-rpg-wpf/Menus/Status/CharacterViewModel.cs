using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Wpf.Menus.Status
{
    public class CharacterViewModel : ViewModel
    {
        private readonly PlayerCharacter _playerCharacter;

        #region Creation

        public CharacterViewModel(PlayerCharacter playerCharacter)
        {
            _playerCharacter = playerCharacter;
        }

        #endregion

        #region Public Interface

        public short Hp => _playerCharacter.EffectiveStats.Hp.Value;
        public byte Level => _playerCharacter.Progression.CurrentLevel.Value;
        public string Name => _playerCharacter.Name.Value;

        #endregion
    }
}
