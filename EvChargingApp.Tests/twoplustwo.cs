using Xunit;

public class MathTests
{
    [Fact]
    public void Test_Addition()
    {
        // Arrange
        int a = 2;
        int b = 2;

        // Act
        int result = a + b;

        // Assert
        Assert.Equal(4, result);
    }
}
