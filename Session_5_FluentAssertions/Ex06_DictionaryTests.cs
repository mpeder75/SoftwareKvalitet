using FluentAssertions;

namespace Session_5_FluentAssertions;
public class Ex06_DictionaryTests
{
    [Fact]
    public void Translating_1337_to_leet_speak_is_leet()
    {
        // Arrange
        var expectedKey = 1337;
        var expectedValue = "leet";

        // Act
        var leetSpeak = GetLeetSpeak();

        // Assert
        leetSpeak.Should().ContainKey(expectedKey);
        leetSpeak[expectedKey].Should().Be(expectedValue);
    }

    #region Helpers

    private static Dictionary<int, string> GetLeetSpeak()
    {
        return new Dictionary<int, string>
        {
            [1337] = "leet",
            [0xBADC0DE] = "leet"
        };
    }

    #endregion
}