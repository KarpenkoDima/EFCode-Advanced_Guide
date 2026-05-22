namespace Dispancer.Domain.ValueObjects;

public record AddressDetails
{
    public string? Region { get; init; }
    public string? Country { get; init; }
    public required string City { get; init; }
    public string? NameStreet { get; init; }
    public string? NumberHouse { get; init; }
    public string? NumberApartment { get; init; }

    private AddressDetails()
    { }

    public static AddressDetails Create(
        string region,
        string? country,
        string city,
        string? nameStreet,
        string? numberHouse,
        string? numberApartment)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(city, nameof(city));

        return new AddressDetails
        {
            City = city.Trim(),
            Region = region?.Trim(),
            Country = country?.Trim(),
            NameStreet = nameStreet?.Trim(),
            NumberHouse = numberHouse?.Trim(),
            NumberApartment = numberApartment?.Trim()
        };
    }

    public string Display =>
        string.Join(", ", new[]
        {
            Region, Country, City,
            NameStreet is not null ? $"{NameStreet}" : null,
            NumberHouse is not null ? $"д. {NameStreet}" : null,
            NumberApartment is not null ? $" кв. {NameStreet}" : null,
        }.Where(s => s is not null));
}