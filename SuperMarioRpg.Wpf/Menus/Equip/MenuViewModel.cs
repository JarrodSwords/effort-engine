using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Controls;

namespace SuperMarioRpg.Wpf.Menus.Equip
{
    public class MenuViewModel : GameState
    {
        private readonly Character _character;

        #region Creation

        public MenuViewModel(Character character)
        {
            _character = character;
            SetControllerState(new MenuControlState());
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
