using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Controls;
using SuperMarioRpg.Wpf.Menus.Status;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;

namespace SuperMarioRpg.Wpf.Main
{
    public class MainWindowViewModel : ViewModel, IControlState
    {
        private GameState _activeViewModel;

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

        public GameState ActiveViewModel
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

        #region IControlState Implementation

        public Command ACommand => _activeViewModel.ACommand;
        public Command BCommand => _activeViewModel.BCommand;
        public Command DownCommand => _activeViewModel.DownCommand;
        public Command LCommand => _activeViewModel.LCommand;
        public Command LeftCommand => _activeViewModel.LeftCommand;
        public Command RCommand => _activeViewModel.RCommand;
        public Command RightCommand => _activeViewModel.RightCommand;
        public Command SelectCommand => _activeViewModel.SelectCommand;
        public Command StartCommand => _activeViewModel.StartCommand;
        public Command UpCommand => _activeViewModel.UpCommand;
        public Command XCommand => _activeViewModel.XCommand;
        public Command YCommand => _activeViewModel.YCommand;

        #endregion
    }
}
