using Dispancer.Domain.ValueObjects;

namespace Dispancer.Domain.UnitTests.ValueObjects;

public sealed class FullNameTests
{
    [Fact]
    public void Create_WithValidValues_TrimsAllNameParts()
    {
        // Arrange
        const string lastName = "  Иванов  ";
        const string firstName = "  Иван  ";
        const string middleName = "  Иванович  ";

        // Act
        FullName fullName = FullName.Create(
            lastName,
            firstName,
            middleName);

        // Assert
        Assert.Equal("Иванов", fullName.LastName);
        Assert.Equal("Иван", fullName.FirstName);
        Assert.Equal("Иванович", fullName.MiddleName);
    }

    [Fact]
    public void Create_WithMiddleName_BuildsDisplayValues()
    {
        // Act
        FullName fullName = FullName.Create(
            "Иванов",
            "Иван",
            "Иванович");

        // Assert
        Assert.Equal("Иванов И.И.", fullName.ShortName);
        Assert.Equal("Иванов Иван Иванович", fullName.FullDisplay);
    }

    [Fact]
    public void Create_WithoutMiddleName_BuildsDisplayValues()
    {
        // Act
        FullName fullName = FullName.Create(
            "Иванов",
            "Иван");

        // Assert
        Assert.Null(fullName.MiddleName);
        Assert.Equal("Иванов И.", fullName.ShortName);
        Assert.Equal("Иванов Иван", fullName.FullDisplay);
    }
}