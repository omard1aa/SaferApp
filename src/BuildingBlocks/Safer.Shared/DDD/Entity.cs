namespace Safer.Shared.DDD;

public abstract class Entity
{
    public Guid Id { get; protected set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
    }

    private List<object> _domainEvents;
    public IReadOnlyCollection<object> DomainEvents => _domainEvents?.AsReadOnly();

    public void AddDomainEvent(object eventItem)
    {
        _domainEvents = _domainEvents ?? new List<object>();
        _domainEvents.Add(eventItem);
    }

    public void RemoveDomainEvent(object eventItem)
    {
        _domainEvents?.Remove(eventItem);
    }

    public void ClearDomainEvents()
    {
        _domainEvents?.Clear();
    }
}
