using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Domain.Common;

public abstract class BaseEntity
{
    private readonly List<object> _domainEvents = [];

    public IReadOnlyCollection<object> DomainEvents
        => _domainEvents;

    public void AddDomainEvent(object domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}
