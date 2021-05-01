﻿namespace Effort.Domain.Messages
{
    public interface ICommandHandler<in T> where T : ICommand
    {
        void Handle(T command);
    }
}
