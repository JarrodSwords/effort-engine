using SuperMarioRpg.Wpf.Controls;
using SuperMarioRpg.Wpf.Main;

namespace SuperMarioRpg.Wpf
{
    public abstract class GameState : ViewModel, IControlState
    {
        private IControlState _controlState = Controls.ControlState.Default;

        #region Creation

        protected GameState(MainWindowViewModel game)
        {
            Game = game;
        }

        #endregion

        #region Public Interface

        public IControlState ControlState
        {
            get => _controlState;
            protected set => SetProperty(ref _controlState, value);
        }

        #endregion

        #region Protected Interface

        protected MainWindowViewModel Game { get; }

        #endregion

        #region IControlState Implementation

        public Command ACommand => _controlState.ACommand;
        public Command BCommand => _controlState.BCommand;
        public Command DownCommand => _controlState.DownCommand;
        public Command LCommand => _controlState.LCommand;
        public Command LeftCommand => _controlState.LeftCommand;
        public Command RCommand => _controlState.RCommand;
        public Command RightCommand => _controlState.RightCommand;
        public Command SelectCommand => _controlState.SelectCommand;
        public Command StartCommand => _controlState.StartCommand;
        public Command UpCommand => _controlState.UpCommand;
        public Command XCommand => _controlState.XCommand;
        public Command YCommand => _controlState.YCommand;

        #endregion
    }
}
