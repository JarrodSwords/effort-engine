using SuperMarioRpg.Wpf.Controls;
using SuperMarioRpg.Wpf.Overworld;

namespace SuperMarioRpg.Wpf.Main
{
    public class MainWindowViewModel : ViewModel, IControlState
    {
        private GameState _gameState;

        #region Creation

        public MainWindowViewModel()
        {
            GameState = new Field(this);
        }

        #endregion

        #region Public Interface

        public GameState GameState
        {
            get => _gameState;
            private set => SetProperty(ref _gameState, value);
        }

        public void SetGameState(GameState state)
        {
            GameState = state;
        }

        #endregion

        #region IControlState Implementation

        public Command ACommand => _gameState.ACommand;
        public Command BCommand => _gameState.BCommand;
        public Command DownCommand => _gameState.DownCommand;
        public Command LCommand => _gameState.LCommand;
        public Command LeftCommand => _gameState.LeftCommand;
        public Command RCommand => _gameState.RCommand;
        public Command RightCommand => _gameState.RightCommand;
        public Command SelectCommand => _gameState.SelectCommand;
        public Command StartCommand => _gameState.StartCommand;
        public Command UpCommand => _gameState.UpCommand;
        public Command XCommand => _gameState.XCommand;
        public Command YCommand => _gameState.YCommand;

        #endregion
    }
}
