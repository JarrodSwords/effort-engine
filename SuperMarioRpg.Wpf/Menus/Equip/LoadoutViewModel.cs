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

        public string Accessory => _loadout.Accessory.Name.Value;
        public string Armor => _loadout.Armor.Name.Value;
        public string Weapon => _loadout.Weapon.Name.Value;

        #endregion
    }
}
