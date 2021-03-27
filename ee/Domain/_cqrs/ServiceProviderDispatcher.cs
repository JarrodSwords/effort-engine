using System;

namespace Effort.Domain
{
    public class ServiceProviderDispatcher : IDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        #region Creation

        public ServiceProviderDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        #endregion

        #region IDispatcher Implementation

        public void Dispatch(ICommand command)
        {
            var type = typeof(ICommandHandler<>);
            Type[] typeArgs = { command.GetType() };

            var handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _serviceProvider.GetService(handlerType);

            handler.Handle((dynamic) command);
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            var type = typeof(IQueryHandler<,>);
            Type[] typeArgs = { query.GetType(), typeof(T) };

            var handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _serviceProvider.GetService(handlerType);

            var result = handler.Handle((dynamic) query);
            return result;
        }

        #endregion
    }
}
