using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.EquipMenu;

namespace SuperMarioRpg.Wpf.Main
{
    public class MainWindowViewModel : ViewModel
    {
        #region Creation

        public MainWindowViewModel()
        {
            var builder = new NewCharacterBuilder();
            new Director().Configure(builder);
            var character = builder.Build();

            EquipMenuViewModel = new EquipMenuViewModel(character);
        }

        #endregion

        #region Public Interface

        public EquipMenuViewModel EquipMenuViewModel { get; }

        #endregion
    }
}
