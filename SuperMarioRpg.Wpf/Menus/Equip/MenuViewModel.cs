using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Wpf.Menus.Equip
{
    public class MenuViewModel : ControllableViewModel
    {
        private readonly Character _character;

        #region Creation

        public MenuViewModel(Character character)
        {
            _character = character;
            SetControllerState(new MenuControllerState());
        }

        #endregion

        #region Public Interface

        public LoadoutViewModel LoadoutViewModel => new(_character.Loadout);
        public StatsViewModel StatsViewModel => new(_character.EffectiveStats);

        #endregion
    }

    public class MenuControllerState : ControllerState
    {
        public MenuControllerState()
        {
            BCommand = new Command(Cancel);
        }

        public void Cancel()
        {
            var x = 10;
        }
    }
}
