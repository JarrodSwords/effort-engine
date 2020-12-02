using SuperMarioRpg.Wpf.Controls;

namespace SuperMarioRpg.Wpf
{
    public abstract class GameState : ViewModel, IControlState
    {
        private IControlState _controlState = Controls.ControlState.Default;

        #region Public Interface

        public IControlState ControlState
        {
            get => _controlState;
            set
            {
                if (_controlState == value)
                    return;

                _controlState = value;
            }
        }

        public void SetControllerState(IControlState state)
        {
            ControlState = state;
        }

        #endregion

        #region Implementation of IControlState

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
