using FluentAssertions;

namespace Session_5_FluentAssertions;

public class Ex03_NumericTests
{
    [Fact]
    public void
        The_answer_to_the_ultimate_question_of_life_the_universe_and_everything_according_to_Douglas_Adams_is_42()
    {
        // Arrange
        var expected = 42;

        // Act
        var result = TheAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything();

        // Assert
        result.Should().Be(expected);
    }

    [Fact]
    public void A_millionaire_donating_to_scouts_still_has_a_positive_balance()
    {
        // Arrange
        var account = new BankAccount
        {
            Balance = 1_000_000
        };

        // Act
        account.DonateToScouts();

        // Assert
        account.Balance.Should().BePositive();
    }

    [InlineData(2020)]
    [InlineData(2021)]
    [Theory]
    public void February_has_28_or_29_days(int year)
    {
        // Act
        var result = DateTime.DaysInMonth(year, 2);

        // Assert
        result.Should().BeInRange(28, 29);
    }

    [Fact]
    public void The_Primary_School_Pi_approximates_Math_PI_by_a_100th()
    {
        // Arrange
        var pi = Math.PI;

        // Act
        var primarySchoolPi = GetPrimarySchoolPi();

        // Assert
        primarySchoolPi.Should().BeApproximately(pi, 0.01);
    }

    #region Helpers

    private class BankAccount
    {
        public decimal Balance { get; set; }

        public void DonateToScouts()
        {
            Balance -= new Random().Next(0, 100);
        }
    }

    private static int TheAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything()
    {
        return 42;
    }

    private static double GetPrimarySchoolPi()
    {
        return 22 / 7d;
    }

    #endregion
}