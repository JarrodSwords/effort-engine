using SuperMarioRpg.Domain.Combat;
using SuperMarioRpg.Wpf.Controls;
using SuperMarioRpg.Wpf.Main;
using SuperMarioRpg.Wpf.Menus.Equip;
using SuperMarioRpg.Wpf.Menus.Root;
using static SuperMarioRpg.Domain.Combat.EquipmentFactory;

namespace SuperMarioRpg.Wpf.Overworld
{
    public class Field : GameState
    {
        #region Creation

        public Field(MainWindowViewModel game) : base(game)
        {
            ControlState = new FieldControlState(this);
        }

        #endregion

        #region Public Interface

        public void OpenMenu()
        {
            var builder = new NewCharacterBuilder();
            new Director().Configure(builder);
            var character = builder
                .Build()
                .Equip(Hammer)
                .Equip(Shirt)
                .Equip(ExpBooster);

            Game.SetGameState(new RootMenuViewModel(Game));
        }

        #endregion

        #region Nested Types

        public class FieldControlState : ControlState
        {
            #region Creation

            public FieldControlState(Field field)
            {
                XCommand = new Command(field.OpenMenu);
            }

            #endregion
        }

        #endregion
    }
}
