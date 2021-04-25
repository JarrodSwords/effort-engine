using System;
using System.Windows.Input;

namespace SuperMarioRpg.Wpf
{
    public class Command : Command<object>
    {
        public static Command Default = new(() => { });

        #region Creation

        public Command(Action execute) : this(execute, _ => true)
        {
        }

        public Command(Action execute, Func<object, bool> canExecute) : base(
            _ => execute(),
            canExecute
        )
        {
        }

        #endregion
    }

    public class Command<T> : ICommand
    {
        private readonly Func<T, bool> _canExecute;
        private readonly Action<T> _execute;

        #region Creation

        public Command(Action<T> execute) : this(execute, _ => true)
        {
        }

        public Command(Action<T> execute, Func<T, bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        #endregion

        #region Public Interface

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region ICommand Implementation

        public bool CanExecute(object parameter)
        {
            return _canExecute((T) parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T) parameter);
        }

        #endregion
    }
}
