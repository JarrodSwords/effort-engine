namespace SuperMarioRpg.Wpf.Controls
{
    public partial class ControlState : IControlState
    {
        public static ControlState Default = new NullControlState();

        #region IControlState Implementation

        public Command ACommand { get; init; } = Command.Default;
        public Command BCommand { get; init; } = Command.Default;
        public Command DownCommand { get; init; } = Command.Default;
        public Command LCommand { get; init; } = Command.Default;
        public Command LeftCommand { get; init; } = Command.Default;
        public Command RCommand { get; init; } = Command.Default;
        public Command RightCommand { get; init; } = Command.Default;
        public Command SelectCommand { get; init; } = Command.Default;
        public Command StartCommand { get; init; } = Command.Default;
        public Command UpCommand { get; init; } = Command.Default;
        public Command XCommand { get; init; } = Command.Default;
        public Command YCommand { get; init; } = Command.Default;

        #endregion
    }
}
