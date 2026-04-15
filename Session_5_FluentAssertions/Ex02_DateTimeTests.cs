using FluentAssertions;
using FluentAssertions.Extensions;

namespace Session_5_FluentAssertions
{
    public class Ex02_DateTimeTests
    {
        [Fact]
        public void In_2026_Easter_Sunday_Falls_On_April_5th()
        {
            // Arrange
            var expected = 05.April(2026);

            // Act
            DateTime date = EasterSunday();

            // Assert
            expected.Should().Be(date);
        }

        [Fact]
        public void The_start_of_this_presentation_is_close_to_the_scheduled_time_give_or_take_5_minutes()
        {
            // Arrange
            var expectedStartOfLecture = 07.April(2026).At(08.Hours(30.Minutes()));

            // Act
            DateTime date = StartOfThisPresentation();

            // Assert
            expectedStartOfLecture.Should().BeCloseTo(date, TimeSpan.FromMinutes(5));
        }

        [Fact]
        public void In_2026_Danish_daylight_saving_time_ends_25th_of_October_at_0300_GMT_Plus2()
        {
            // Express expectedEndOfDst using the Fluent API from FluentAssertions.Extensions
            // See https://fluentassertions.com/datetimespans/ for examples

            // Arrange
            var localDateTime = 25.October(2026).At(3.Hours()); // her bliver localDateTime defineret
            DateTimeOffset expectedEndOfDst = new DateTimeOffset(localDateTime, TimeSpan.FromHours(2));

            // Act
            DateTimeOffset date = DaylightSavingTimeEnd();

            // Assert
            date.Should().Be(expectedEndOfDst);
        }

        #region Helpers
        private static DateTime EasterSunday() => new(2026, 04, 05);

        private static DateTime StartOfThisPresentation() => new DateTime(2026, 04, 07, 08, 30, 00).AddMinutes(new Random().Next(-5, 5));

        private static DateTimeOffset DaylightSavingTimeEnd() => new(2026, 10, 25, 03, 00, 00, TimeSpan.FromHours(2));
        #endregion
    }
}

