using Training.forloops;

namespace TestTraining
{
    public class UnitTestForloops
    {
        [Fact]
        public void Test()
        {
            // Arrange
            List<int> testList = new List<int>{1,2,3,4,5,6,7,8,9};

            // Act
            Forloop forloop = new Forloop();

            // Assert
            Assert.Equal(forloop.SumList(testList),45);
        }
    }
}
