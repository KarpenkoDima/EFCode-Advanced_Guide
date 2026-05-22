namespace Dispancer.Domain.Lookup;

public sealed class ApppPtr
{
    public int AppptprId { get; init; }
    public required string Name { get; init; }   // nchar(5)

    public IReadOnlyCollection<Customer> Customers => _customers;
    private readonly HashSet<Customer> _customers = [];
}