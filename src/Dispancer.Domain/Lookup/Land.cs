namespace Dispancer.Domain.Lookup;

public sealed class Land
{
    public int LandId { get; init; }
    public required string Numberland { get; init; }
    public string? NotaBene { get; init; }
    
    public IReadOnlyCollection<Register> Registers => _registers;
    private readonly HashSet<Register> _registers = [];
}