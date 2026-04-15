using FluentAssertions;

namespace Session_5_FluentAssertions;

public class Ex04_StringTests
{
    [Fact]
    public void A_default_person_has_a_non_empty_star_sign()
    {
        // Arrange
        var person = new Person();

        // Act
        var starSign = person.GetStarSign();

        // Assert
        starSign.Should().NotBeNullOrEmpty();
    }

    [Fact]
    public void This_test_framework_ignoring_casing_is_xunit()
    {
        // Arrange
        var expectedFrameworkName = "xunit";

        // Act
        var frameworkName = GetTestFramework();

        // Assert
        frameworkName.Should().BeEquivalentTo(expectedFrameworkName);
    }

    [Fact]
    public void Donald_Duck_has_a_nephew_named_Louie()
    {
        // Arrange
        var expectedNephew = "Louie";

        // Act
        var nephews = GetNephewsOfDonaldDuck();

        // Assert
        nephews.Should().Contain(expectedNephew);
    }

    [Fact]
    public void The_Danish_alphabeth_has_29_letters()
    {
        // Arrange
        var expectedLength = 29;

        // Act
        var alphabet = GetDanishAlphabeth();

        // Assert
        alphabet.Length.Should().Be(expectedLength);
    }

    [Fact]
    public void The_error_message_matches_Foo_and_Bar_in_that_order()
    {
        // Act
        var errorMessage = GetErrorMessage();

        // Assert
        errorMessage.Should().Match("*Foo*Bar*");
    }

    #region Helpers

    private class Person
    {
        public string GetStarSign()
        {
            return "Taurus";
        }
    }

    public static string GetTestFramework()
    {
        return "xUniT";
    }

    public static string[] GetNephewsOfDonaldDuck()
    {
        return ["Huey", "Louie", "Dewey"];
    }

    public static string GetDanishAlphabeth()
    {
        return "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
    }

    public static string GetErrorMessage()
    {
        return "Yada Yada Foo Yada Yada Bar Yada Yada";
    }

    #endregion
}