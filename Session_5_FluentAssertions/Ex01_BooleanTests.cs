using FluentAssertions;

namespace Session_5_FluentAssertions;

public class Ex01_BooleanTests
{
    [Fact]
    public void Adults_are_allowed_to_buy_alcohol()
    {
        // Arrange
        var person = new Person
        {
            Age = 18
        };

        // Act
        var result = CanBuyAlcohol(person);

        // Assert
        result.Should().BeTrue("adults 18 or more, are allowed to buy alcohol");
    }

    [Fact]
    public void Children_are_not_allowed_to_buy_alcohol()
    {
        // Arrange
        var person = new Person
        {
            Age = 5
        };

        // Act
        var result = CanBuyAlcohol(person);

        // Assert
        result.Should().BeFalse("children under 18, are not allowed to buy alcohol");
    }

    #region Helpers

    private static bool CanBuyAlcohol(Person person)
    {
        return person.Age >= 18;
    }

    private class Person
    {
        public int Age { get; set; }
    }

    #endregion
}