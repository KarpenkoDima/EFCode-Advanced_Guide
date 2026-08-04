namespace Dispancer.Domain.Interfaces;

public interface IAuditable
{
    DateTime CreatedAt { get; }
    DateTime? ModifiedAt { get; }
    void TouchModifiedAt();
}