using System.Diagnostics;
using Effort.Domain;

namespace SuperMarioRpg.Application
{
    public class CommandLogger<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _handler;

        #region Creation

        public CommandLogger(ICommandHandler<T> handler)
        {
            _handler = handler;
        }

        #endregion

        #region ICommandHandler<T> Implementation

        public void Handle(T command)
        {
            Trace.WriteLine("LogAttribute pre-execution.");

            _handler.Handle(command);

            Trace.WriteLine("LogAttribute post-execution.");
        }

        #endregion
    }
}
