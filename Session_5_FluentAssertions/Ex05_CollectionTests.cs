using FluentAssertions;

namespace Session_5_FluentAssertions;
public class Ex05_CollectionTests
{
    [Fact]
    public void Sortedness()
    {
        // result should be sorted in ascending order

        // Arrange
        var result = new[] { 41, 42, 43 };

        // Assert
        result.Should().BeInAscendingOrder();
    }

    [Fact]
    public void CollectionEquality()
    {
        // The two collections should be identical,
        // i.e. contain the same members in the same order

        // Arrange
        var expected = new[] { 41, 42, 43 };

        // Act
        var result = new[] { 41, 42, 43 };

        // Assert
        expected.Should().Equal(result);
    }

    [Fact]
    public void GetObjects_has_exactly_2_items()
    {
        // Arrange
        var expectedCount = 2;

        // Act
        var objects = GetObjects();

        // Assert
        objects.Should().HaveCount(expectedCount);
    }

    [Fact]
    public void GetObjects_SatisfyRespectively()
    {
        // * The first item should be a string of length 2
        // * The second item should be equal to 42
        // See example of SatisfyRespectively on https://fluentassertions.com/collections/

        // Arrange
        var expectedLength = 2;
        var expectedNumber = 42;

        // Act
        var objects = GetObjects();

        // Assert
        objects.Should().SatisfyRespectively(
            first =>
            {
                first.Should().BeOfType<string>();
                ((string)first).Length.Should().Be(expectedLength);
            },
            second =>
            {
                second.Should().BeOfType<int>();
                ((int)second).Should().Be(expectedNumber);
            });
    }

    [Fact]
    public void BeEquivalentTo_WithoutOrder()
    {
        // Arrange
        var expected = new object[] { 42, "42" };

        // Act
        var objects = GetRandomObjects();

        // Assert
        objects.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void BeEquivalentTo_WithStrictOrder()
    {
        // Arrange
        object[] expectedNumbers = ["42", 42];

        // Act
        var objects = GetObjects();

        // Assert
        objects.Should().BeEquivalentTo(expectedNumbers, options => options.WithStrictOrdering());
    }

    #region Helpers

    private class Person
    {
        public string Name { get; set; }

        public string Company { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Person person
                   && Name == person.Name
                   && Company == person.Company;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Company);
        }
    }

    private static object[] GetObjects()
    {
        return ["42", 42];
    }

    private static object[] GetRandomObjects()
    {
        return new Random().Next(0, 1) > 0
            ? ["42", 42]
            : [42, "42"];
    }

    #endregion
}