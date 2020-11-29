using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Wpf.EquipMenu
{
    public class EquipMenuViewModel : ViewModel
    {
        private readonly Character _character;

        #region Creation

        public EquipMenuViewModel(Character character)
        {
            _character = character;
        }

        #endregion

        #region Public Interface

        public LoadoutViewModel LoadoutViewModel => new(_character.Loadout);
        public StatsViewModel StatsViewModel => new(_character.EffectiveStats);

        #endregion
    }
}
