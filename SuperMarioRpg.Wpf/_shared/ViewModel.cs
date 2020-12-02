using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SuperMarioRpg.Wpf
{
    public abstract class ViewModel
    {
        #region Public Interface

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Protected Interface

        protected void Notify([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

    public abstract class ControllableViewModel : ViewModel, IControllerState
    {
        private IControllerState _controllerState = Wpf.ControllerState.Default;

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

    public interface IControllerState
    {
        #region Public Interface

        Command ACommand { get; }
        Command BCommand { get; }
        Command DownCommand { get; }
        Command LCommand { get; }
        Command LeftCommand { get; }
        Command RCommand { get; }
        Command RightCommand { get; }
        Command SelectCommand { get; }
        Command StartCommand { get; }
        Command UpCommand { get; }
        Command XCommand { get; }
        Command YCommand { get; }

        #endregion
    }

    public class NullControllerState : ControllerState
    {
    }

    public abstract class ControllerState : IControllerState
    {
        public static ControllerState Default = new NullControllerState();

        #region IControllerState Implementation

        public Command ACommand { get; protected init; } = Command.Default;
        public Command BCommand { get; protected init; } = Command.Default;
        public Command DownCommand { get; protected init; } = Command.Default;
        public Command LCommand { get; protected init; } = Command.Default;
        public Command LeftCommand { get; protected init; } = Command.Default;
        public Command RCommand { get; protected init; } = Command.Default;
        public Command RightCommand { get; protected init; } = Command.Default;
        public Command SelectCommand { get; protected init; } = Command.Default;
        public Command StartCommand { get; protected init; } = Command.Default;
        public Command UpCommand { get; protected init; } = Command.Default;
        public Command XCommand { get; protected init; } = Command.Default;
        public Command YCommand { get; protected init; } = Command.Default;

        #endregion
    }
}
