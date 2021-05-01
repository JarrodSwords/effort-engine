using SuperMarioRpg.Domain.Combat;

namespace SuperMarioRpg.Wpf.Menus.Equip
{
    public class LoadoutViewModel : ViewModel
    {
        private readonly Loadout _loadout;

        #region Creation

        public LoadoutViewModel(Loadout loadout)
        {
            _loadout = loadout;
        }

        #endregion

        #region Public Interface

        public string Accessory => _loadout.Accessory.Name;
        public string Armor => _loadout.Armor.Name;
        public string Weapon => _loadout.Weapon.Name;

        #endregion
    }
}
