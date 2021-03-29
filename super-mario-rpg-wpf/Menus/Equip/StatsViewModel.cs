using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Wpf.Menus.Equip
{
    public class StatsViewModel : ViewModel
    {
        private readonly Stats _stats;

        #region Creation

        public StatsViewModel(Stats stats)
        {
            _stats = stats;
        }

        #endregion

        #region Public Interface

        public short Attack => _stats.Attack.Value;
        public short Defense => _stats.Defense.Value;
        public short MagicAttack => _stats.SpecialAttack.Value;
        public short MagicDefense => _stats.SpecialDefense.Value;

        #endregion
    }
}
