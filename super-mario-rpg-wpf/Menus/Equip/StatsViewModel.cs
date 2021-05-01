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

        public short Attack => _stats.Attack;
        public short Defense => _stats.Defense;
        public short MagicAttack => _stats.SpecialAttack;
        public short MagicDefense => _stats.SpecialDefense;

        #endregion
    }
}
