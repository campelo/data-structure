namespace Dynamic.Tests;

public class FibonacciTests
{
    [Theory]
    [InlineData(0,0)]
    [InlineData(1, 1)]
    [InlineData(2, 1)]
    [InlineData(3, 2)]
    [InlineData(4, 3)]
    [InlineData(5, 5)]
    [InlineData(6, 8)]
    [InlineData(40, 102334155)]
    [InlineData(50, 12586269025)]
    [InlineData(60, 1548008755920)]
    public void GetFibNum(int numPosition, long expectedResult)
    {
        var result = Fibonacci.GetFibNum(numPosition);
        result.ShouldBe(expectedResult);
    }
}