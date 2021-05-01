using SuperMarioRpg.Domain.Old.Combat;
using SuperMarioRpg.Wpf.Controls;
using SuperMarioRpg.Wpf.Main;

namespace SuperMarioRpg.Wpf.Menus.Equip
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

        public LoadoutViewModel LoadoutViewModel => new(_playerCharacter.Loadout);
        public StatsViewModel StatsViewModel => new(_playerCharacter.EffectiveStats);

        #endregion
    }

    public class MenuControlState : ControlState
    {
        #region Creation

        public MenuControlState()
        {
            BCommand = new Command(Cancel);
        }

        #endregion

        #region Public Interface

        public void Cancel()
        {
            var x = 10;
        }

        #endregion
    }
}
