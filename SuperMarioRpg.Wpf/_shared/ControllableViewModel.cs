using SuperMarioRpg.Wpf.Controls;

namespace SuperMarioRpg.Wpf
{
    public abstract class ControllableViewModel : ViewModel, IControllerState
    {
        private IControllerState _controllerState = Controls.ControllerState.Default;

        #region Public Interface

        public IControllerState ControllerState
        {
            get => _controllerState;
            set
            {
                if (_controllerState == value)
                    return;

                _controllerState = value;
            }
        }

        public void SetControllerState(IControllerState state)
        {
            ControllerState = state;
        }

        #endregion

        #region IControllerState Implementation

        public Command ACommand => _controllerState.ACommand;
        public Command BCommand => _controllerState.BCommand;
        public Command DownCommand => _controllerState.DownCommand;
        public Command LCommand => _controllerState.LCommand;
        public Command LeftCommand => _controllerState.LeftCommand;
        public Command RCommand => _controllerState.RCommand;
        public Command RightCommand => _controllerState.RightCommand;
        public Command SelectCommand => _controllerState.SelectCommand;
        public Command StartCommand => _controllerState.StartCommand;
        public Command UpCommand => _controllerState.UpCommand;
        public Command XCommand => _controllerState.XCommand;
        public Command YCommand => _controllerState.YCommand;

        #endregion
    }
}
