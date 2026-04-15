using FluentAssertions;
using System.Diagnostics;

namespace Session_5_FluentAssertions;
public class Ex08_ExceptionTests
{
    [Fact]
    public void DoesThrow_WrappedInAction_ThrowInvalidOperationException()
    {
        // Arrange
        var subject = new Thrower();

        // Act
        var act = () => subject.DoesThrow();

        // Assert
        act.Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void DoesThrow_ThrowInvalidOperationAdvanced()
    {
        // Arrange
        var subject = new Thrower();

        // Act
        var act = () => subject.DoesThrow();

        // Assert
        act.Should().Throw<InvalidOperationException>()
            .WithMessage("*foobar*")
            .WithInnerExceptionExactly<DivideByZeroException>()
            .Which.Message.Should().Contain("Dark Side");
    }

    #region Helpers

    private class Thrower
    {
        [DebuggerNonUserCode]
        public void DoesThrow()
        {
            throw new InvalidOperationException("Yada Yada foobar Yada Yada",
                new DivideByZeroException("Something, Something, Something, Dark Side"));
        }

        public int DoesNotThrow()
        {
            return 42;
        }

        public Task DoesThrowAsync()
        {
            DoesThrow();
            return Task.CompletedTask;
        }

        public Task<int> DoesNotThrowAsync()
        {
            return Task.FromResult(DoesNotThrow());
        }
    }

    #endregion
}