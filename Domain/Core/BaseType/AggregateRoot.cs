using Domain.Core.Events;

namespace Domain.Core.BaseType;

public abstract class AggregateRoot : Entity
{
    protected AggregateRoot(Guid id) : base(id) { }  

    protected AggregateRoot() : base() { }

    private readonly List<IDomainEvent> domainEvents = [];

    public void RaiseDomainEvent(IDomainEvent @event) => domainEvents.Add(@event);

    public void ClearDomainEvent() => domainEvents.Clear();
}
