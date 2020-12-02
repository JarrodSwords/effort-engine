﻿namespace SuperMarioRpg.Wpf.Controls
{
    public abstract partial class ControllerState : IControllerState
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
