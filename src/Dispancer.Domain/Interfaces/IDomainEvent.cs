namespace Dispancer.Domain.Interfaces;

public interface IDomainEvent
{
    Guid EventID { get; }
    DateTime OccuredAt { get; }
}