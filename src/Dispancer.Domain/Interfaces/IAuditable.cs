namespace Dispancer.Domain.Interfaces;

public interface IAuditable
{
    DateTime CreatedAt { get; }
    DateTime? ModifedAt { get; }
    void TouchModifiedAt();
}