using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Main;
using SuperMarioRpg.Wpf.Menus.Equip;

namespace SuperMarioRpg.Wpf.Menus.Status
{
    public class MenuViewModel : GameState
    {
        private readonly PlayerCharacter _playerCharacter;

        #region Creation

        public MenuViewModel(MainWindowViewModel game, PlayerCharacter playerCharacter) : base(game)
        {
            _playerCharacter = playerCharacter;
            ControlState = new MenuControlState();
        }

        #endregion

        #region Public Interface

        public CharacterViewModel CharacterViewModel => new(_playerCharacter);
        public StatsViewModel StatsViewModel => new(_playerCharacter);

        #endregion
    }
}
