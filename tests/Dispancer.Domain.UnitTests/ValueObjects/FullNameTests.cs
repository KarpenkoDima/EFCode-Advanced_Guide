using Dispancer.Domain.ValueObjects;

namespace Dispancer.Domain.UnitTests.ValueObjects;

public sealed class FullNameTests
{
    [Fact]
    public void Create_WithValidValues_TrimsAllNameParts()
    {
        // Act
        FullName fullName = FullName.Create(
            "  Иванов  ",
            "  Иван  ",
            "  Иванович  ");

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
        Assert.Equal(
            "Иванов Иван Иванович",
            fullName.FullDisplay);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithMissingMiddleName_NormalizesItToNull(
        string? middleName)
    {
        // Act
        FullName fullName = FullName.Create(
            "Иванов",
            "Иван",
            middleName);

        // Assert
        Assert.Null(fullName.MiddleName);
        Assert.Equal("Иванов И.", fullName.ShortName);
        Assert.Equal("Иванов Иван", fullName.FullDisplay);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithInvalidLastName_ThrowsArgumentException(
        string? lastName)
    {
        // Act
        ArgumentException exception =
            Assert.ThrowsAny<ArgumentException>(
                () => FullName.Create(
                    lastName!,
                    "Иван"));

        // Assert
        Assert.Equal("lastName", exception.ParamName);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void Create_WithInvalidFirstName_ThrowsArgumentException(
        string? firstName)
    {
        // Act
        ArgumentException exception =
            Assert.ThrowsAny<ArgumentException>(
                () => FullName.Create(
                    "Иванов",
                    firstName!));

        // Assert
        Assert.Equal("firstName", exception.ParamName);
    }

    [Fact]
    public void SameNameParts_AreValueEqual()
    {
        // Arrange
        FullName first = FullName.Create(
            "Иванов",
            "Иван",
            "Иванович");

        FullName second = FullName.Create(
            "Иванов",
            "Иван",
            "Иванович");

        // Assert
        Assert.Equal(first, second);
    }
}