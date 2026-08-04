namespace Dispancer.Domain.ValueObjects;

/// <summary>
/// Полное имя человека.
///
/// Value object не имеет собственного идентификатора.
/// Два экземпляра с одинаковыми частями имени считаются равными.
/// </summary>
public sealed record FullName
{
    private FullName(
        string lastName,
        string firstName,
        string? middleName)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
    }

    public string LastName { get; }

    public string FirstName { get; }

    public string? MiddleName { get; }

    /// <summary>
    /// Создаёт нормализованное полное имя.
    /// </summary>
    public static FullName Create(
        string lastName,
        string firstName,
        string? middleName = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(
            lastName,
            nameof(lastName));

        ArgumentException.ThrowIfNullOrWhiteSpace(
            firstName,
            nameof(firstName));

        return new FullName(
            lastName.Trim(),
            firstName.Trim(),
            NormalizeOptional(middleName));
    }

    /// <summary>
    /// Краткое представление: Иванов И.И.
    /// </summary>
    public string ShortName => MiddleName is null
        ? $"{LastName} {FirstName[0]}."
        : $"{LastName} {FirstName[0]}.{MiddleName[0]}.";

    /// <summary>
    /// Полное представление: Иванов Иван Иванович.
    /// </summary>
    public string FullDisplay => MiddleName is null
        ? $"{LastName} {FirstName}"
        : $"{LastName} {FirstName} {MiddleName}";

    private static string? NormalizeOptional(string? value)
    {
        return string.IsNullOrWhiteSpace(value)
            ? null
            : value.Trim();
    }
}