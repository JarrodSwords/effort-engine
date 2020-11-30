using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Menus.Status;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;

namespace SuperMarioRpg.Wpf.Main
{
    public class MainWindowViewModel : ViewModel
    {
        private ViewModel _activeViewModel;

        #region Creation

        public MainWindowViewModel()
        {
            var builder = new NewCharacterBuilder();
            new Director().Configure(builder);
            var character = builder
                .Build()
                .Equip(Hammer)
                .Equip(Shirt)
                .Equip(ExpBooster);

            ActiveViewModel = new MenuViewModel(character);
        }

        #endregion

        #region Public Interface

        public ViewModel ActiveViewModel
        {
            get => _activeViewModel;
            set
            {
                if (_activeViewModel == value)
                    return;

                _activeViewModel = value;
                Notify(nameof(ActiveViewModel));
            }
        }

        #endregion
    }
}
