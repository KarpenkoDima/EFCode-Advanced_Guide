namespace Dispancer.Domain.ValueObjects;

// record обеспечивает value-equality и иммутабельность "из коробки"
public record FullName
{
    public required string LastName { get; init; }
    public required string FirstName { get; init; }
    public string? MiddleName { get; init; }
    
    // Приватный конструктор - создание только через фабрику
    private FullName()
    { }

    public static FullName Create(string lastName, string firstName, string? middleName = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(lastName, nameof(lastName));
        ArgumentException.ThrowIfNullOrWhiteSpace(firstName, nameof(lastName));

        return new FullName
        {
            LastName = lastName.Trim(),
            FirstName = firstName.Trim(),
            MiddleName = middleName?.Trim()
        };
    }
    
    // Отображение для UI и отчётов — логика принадлежит домену, а не контроллеру
    public string ShortName =>
        $"{LastName} {FirstName[0]}.{(MiddleName is not null ? $"{MiddleName[0]}." : string.Empty)}";

    public string FullDisplay => MiddleName is null
        ? $"{LastName} {FirstName}"
        : $"{LastName} {FirstName} {MiddleName}";
}