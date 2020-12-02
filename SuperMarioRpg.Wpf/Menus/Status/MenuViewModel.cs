using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Menus.Equip;

namespace SuperMarioRpg.Wpf.Menus.Status
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

        public CharacterViewModel CharacterViewModel => new(_character);
        public StatsViewModel StatsViewModel => new(_character);

        #endregion
    }
}
