using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Wpf.Menus.Status
{
    public class MenuViewModel : ViewModel
    {
        private readonly Character _character;

        #region Creation

        public MenuViewModel(Character character)
        {
            _character = character;
        }

        #endregion

        #region Public Interface

        public CharacterViewModel CharacterViewModel => new(_character);
        public StatsViewModel StatsViewModel => new(_character);

        #endregion
    }
}
