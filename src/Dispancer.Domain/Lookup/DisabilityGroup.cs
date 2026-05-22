namespace Dispancer.Domain.Lookup;

public sealed class DisabilityGroup
{
    public int DisabilityGroupId { get; init; }
    public required string Name { get; init; }
    public string? NotaBene { get; init; }

    public IReadOnlyCollection<Invalid> Invalids => _invalids;
    private readonly HashSet<Invalid> _invalids = [];
}