namespace Dynamic.Tests;

public class SumNumberTests
{
    [Theory]
    [InlineData(7, new int[] { 3, 4, 5, 7 }, true)]
    [InlineData(7, new int[] { 7 }, true)]
    [InlineData(7, new int[] { 3, 5 }, false)]
    [InlineData(8, new int[] { 2, 3, 5 }, true)]
    [InlineData(300, new int[] { 7, 14, 21, 28, 56 }, false)]
    [InlineData(300, new int[] { 7, 14, 21, 56, 1 }, true)]
    public void CanSum(int num, int[] values, bool expectedResult)
    {
        var result = SumNumber.CanSum(num, values);
        result.ShouldBe(expectedResult);
    }

    [Theory]
    [InlineData(7, new int[] { 3, 4, 5, 7 }, new int[] { 3, 4 })]
    [InlineData(7, new int[] { 7 }, new int[] { 7 })]
    [InlineData(7, new int[] { 3, 5 }, null)]
    [InlineData(8, new int[] { 2, 3, 5 }, new int[] { 2, 2, 2, 2 })]
    [InlineData(300, new int[] { 7, 14, 21, 28, 56 }, null)]
    [InlineData(300, new int[] { 7, 14, 21, 56, 1 }, new int[] { 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 1, 1, 1, 1, 1, 1 })]
    public void FindSolution(int num, int[] values, int[] expectedResult)
    {
        var result = SumNumber.FindSolution(num, values);
        result.ShouldBe(expectedResult);
    }

    [Theory]
    [InlineData(7, new int[] { 3, 4, 5, 7 }, new int[] { 7 })]
    [InlineData(7, new int[] { 7 }, new int[] { 7 })]
    [InlineData(7, new int[] { 3, 5 }, null)]
    [InlineData(8, new int[] { 2, 3, 5 }, new int[] { 5, 3 })]
    [InlineData(20, new int[] { 2, 5, 10 }, new int[] { 10, 10 })]
    [InlineData(100, new int[] { 1, 2, 5, 25 }, new int[] { 25, 25, 25, 25 })]
    [InlineData(300, new int[] { 7, 14, 21, 28, 56 }, null)]
    [InlineData(300, new int[] { 7, 14, 21, 56, 1 }, new int[] { 56, 56, 56, 1, 1, 1, 1, 1, 1, 56, 56, 14 })]
    public void FindBestSolution(int num, int[] values, int[] expectedResult)
    {
        var result = SumNumber.FindBestSolution(num, values);
        result.ShouldBe(expectedResult);
    }
}
