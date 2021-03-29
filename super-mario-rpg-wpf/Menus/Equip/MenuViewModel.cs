using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Controls;
using SuperMarioRpg.Wpf.Main;

namespace SuperMarioRpg.Wpf.Menus.Equip
{
    public class MenuViewModel : GameState
    {
        private readonly Character _character;

        #region Creation

        public MenuViewModel(MainWindowViewModel game, Character character) : base(game)
        {
            _character = character;
            ControlState = new MenuControlState();
        }

        #endregion

        #region Public Interface

        public LoadoutViewModel LoadoutViewModel => new(_character.Loadout);
        public StatsViewModel StatsViewModel => new(_character.EffectiveStats);

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
