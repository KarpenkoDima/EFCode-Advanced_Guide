namespace Dispancer.Domain.Lookup;

public sealed class Gender
{
    public int GenderId { get; init; }
    public required string Name { get; init; }

    public IReadOnlyCollection<Customer> Customers => _customers;
    private readonly HashSet<Customer> _customers = [];
}