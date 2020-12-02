namespace SuperMarioRpg.Wpf.Controls
{
    public interface IControlState
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
}
