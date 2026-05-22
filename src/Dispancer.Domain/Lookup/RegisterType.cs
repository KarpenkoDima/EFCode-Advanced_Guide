namespace Dispancer.Domain.Lookup;

public class RegisterType
{
    public int RegisterId { get; init; }
    public required string Name { get; init; }
    public string? NotaBene { get; init; }
}