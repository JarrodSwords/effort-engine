using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Menus.Equip;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;

namespace SuperMarioRpg.Wpf.Main
{
    public class MainWindowViewModel : ViewModel
    {
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

            MenuViewModel = new MenuViewModel(character);
        }

        #endregion

        #region Public Interface

        public MenuViewModel MenuViewModel { get; }

        #endregion
    }
}
