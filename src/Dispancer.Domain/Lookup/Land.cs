namespace Dispancer.Domain.Lookup;

public sealed class Land
{
    public int LandId { get; init; }
    public required string Numberland { get; init; }
    public string? NotaBene { get; init; }
    
}