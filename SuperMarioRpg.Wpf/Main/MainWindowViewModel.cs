using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.EquipMenu;
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

            EquipMenuViewModel = new EquipMenuViewModel(character);
        }

        #endregion

        #region Public Interface

        public EquipMenuViewModel EquipMenuViewModel { get; }

        #endregion
    }
}
