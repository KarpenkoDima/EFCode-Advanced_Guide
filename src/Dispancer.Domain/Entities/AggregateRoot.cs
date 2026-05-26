using Dispancer.Domain.Interfaces;

namespace Dispancer.Domain.Entities;

public abstract class AggregateRoot: IHasDomainEvents, IAuditable, ISoftDeletable
{
    private readonly List<IDomainEvent> _domainEvents = [];

    // IHasDomainEvents
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    public void ClearDomainEvents() => _domainEvents.Clear();
    
    protected void RaiseDomainEvent(IDomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);
    
    // IAuditable
    public DateTime CreatedAt { get; private set; }
    public DateTime? ModifiedAt { get; private set; }

    public void TouchModifiedAt() => ModifiedAt = DateTime.UtcNow;

    // ISoftDeletable
    public bool IsDeleted { get; private set; }
    public DateTime? DeletedAt { get; private set; }
    
    // ISoftDeletable - вызывается SoftDeleteInterceptor
    public void MarkAsDeleted()
    {
        IsDeleted = true;
        DeletedAt = DateTime.UtcNow;
    }
    
    // Вызывается только при создании через фабричный метод
    protected void InitAudit()
    {
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }
}