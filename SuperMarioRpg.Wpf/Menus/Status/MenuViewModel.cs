using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Menus.Equip;

namespace SuperMarioRpg.Wpf.Menus.Status
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

        public CharacterViewModel CharacterViewModel => new(_character);
        public StatsViewModel StatsViewModel => new(_character);

        #endregion
    }
}
