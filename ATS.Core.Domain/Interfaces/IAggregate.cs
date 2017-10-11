using System;

namespace ATS.Core.Domain.Interfaces
{
    public interface IAggregate
    {
        Guid Id { get; }
    }
}
