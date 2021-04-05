﻿namespace Effort.Domain.Messages
{
    public interface IQueryHandler<in TQuery, out TResult> where TQuery : IQuery<TResult>
    {
        #region Public Interface

        TResult Handle(TQuery query);

        #endregion
    }
}