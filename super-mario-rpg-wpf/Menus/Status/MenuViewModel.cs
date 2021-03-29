using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Main;
using SuperMarioRpg.Wpf.Menus.Equip;

namespace SuperMarioRpg.Wpf.Menus.Status
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

        public CharacterViewModel CharacterViewModel => new(_character);
        public StatsViewModel StatsViewModel => new(_character);

        #endregion
    }
}
