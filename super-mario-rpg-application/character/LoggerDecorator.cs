using System;
using System.Diagnostics;
using Effort.Domain;

namespace SuperMarioRpg.Application
{
    public class LoggerDecorator<T> : ICommandHandler<T> where T : ICommand
    {
        private readonly ICommandHandler<T> _handler;

        #region Creation

        public LoggerDecorator(ICommandHandler<T> handler)
        {
            _handler = handler;
        }

        #endregion

        #region ICommandHandler<T> Implementation

        public void Handle(T command)
        {
            Debug.WriteLine("Logged pre-execution.");

            _handler.Handle(command);

            Debug.WriteLine("Logged post-execution.");
        }

        #endregion
    }

    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
    public class Logged : Attribute
    {
    }
}
