using System;

namespace Effort.Domain
{
    public record Id(Guid Value) : TinyType<Guid>(Value == default ? Guid.NewGuid() : Value);
}
