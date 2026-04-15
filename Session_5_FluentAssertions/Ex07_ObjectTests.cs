using FluentAssertions;
using FluentAssertions.Extensions;

namespace Session_5_FluentAssertions;

public class Ex07_ObjectTests
{
    [Fact]
    public void BeEquivalentTo_Exclusion()
    {
        // 'expectedInstance' and 'instance' should be equivalent,
        // without taking the 'Id' property into account.

        // Arrange
        var expectedInstance = new Machine
        {
            Name = "HAL"
        };

        // Act
        var instance = GetInstance();

        // Assert
        instance.Should().BeEquivalentTo(expectedInstance, e => e.Excluding(m => m.Id));
    }

    [Fact]
    public void BeEquivalentTo_AnonymousType_OnlyMatchOn42()
    {
        // Arrange
        object expected = new
        {
            Inner = new
            {
                Inner = new
                {
                    MyProperty = 42
                }
            }
        };

        // Act
        var complexResult = GetNested();

        // Assert
        complexResult.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Including()
    {
        // Arrange
        var expected = new AnnoyingClass
        {
            name = "John"
        };

        // Act
        var result = GetResult();

        // Assert
        result.Should().BeEquivalentTo(expected, options =>
            options.Including(a => a.name));
    }

    [Fact]
    public void Using_WhenTypeIs()
    {
        // Arrange
        var dasModel = GetModel();

        // Act
        object mappedModel = ModelMapper.Map(dasModel);

        // Assert
        mappedModel.Should().BeEquivalentTo(dasModel, options =>
            options.Using<DateTime>(ctx =>
                    ctx.Subject.Should().BeCloseTo(ctx.Expectation, 1.Seconds()))
                .WhenTypeIs<DateTime>());
    }

    [Fact]
    public void Using_When()
    {
        // Arrange
        var dasModel = GetModel();

        // Act
        object mappedModel = ModelMapper.Map(dasModel);

        // Assert
        mappedModel.Should().BeEquivalentTo(dasModel, options =>
            options.Using<DateTime>(ctx =>
                    ctx.Subject.Should().BeCloseTo(ctx.Expectation, 1.Seconds()))
                .When(info => info.Path.EndsWith("Created")));
    }

    #region Helpers

    private AnnoyingClass GetResult()
    {
        return new AnnoyingClass { id = new Random().Next(), name = "John" };
    }

    private Person GetPerson()
    {
        return new Person { Name = "John" };
    }

    private class Person
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return false;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }

    private Machine GetInstance()
    {
        return new Machine { Name = "HAL", Id = 9000 };
    }

    private class Machine
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    private class Nested
    {
        public int MyProperty { get; set; }

        public Nested Inner { get; set; }
    }

    private static Nested GetNested()
    {
        var random = new Random();
        return new Nested
        {
            MyProperty = random.Next(),
            Inner = new Nested
            {
                MyProperty = random.Next(),
                Inner = new Nested
                {
                    MyProperty = 42
                }
            }
        };
    }

    private class AnnoyingClass
    {
        public int id;

        public string name;
    }

    private class Model
    {
        public DateTime Created { get; set; }
    }

    private class ModelDto
    {
        public DateTime Created { get; set; }
    }

    private static class ModelMapper
    {
        public static Model Map(ModelDto m)
        {
            return new Model { Created = m.Created + TimeSpan.FromMilliseconds(new Random().Next(1, 42)) };
        }

        public static ModelDto Map(Model m)
        {
            return new ModelDto { Created = m.Created + TimeSpan.FromMilliseconds(new Random().Next(1, 42)) };
        }
    }

    private static Model GetModel()
    {
        return new Model { Created = 19.May(1978) };
    }

    #endregion
}