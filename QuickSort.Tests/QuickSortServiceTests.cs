using Shouldly;

namespace QuickSort.Tests
{
    public class QuickSortServiceTests
    {
        [Theory]
        [InlineData(new int[] { }, new int[] { })]
        [InlineData(new int[] { 1 }, new int[] { 1 })]
        [InlineData(new int[] { 2, 3, 1}, new int[] { 1,2,3 })]
        [InlineData(new int[] { 7, 5, 22, 11, 33, 1, 4 }, new int[] { 1, 4, 5, 7,11,22,33 })]
        [InlineData(new int[] { 10,16,8,12,15,6,3,9,5}, new int[] { 3,5,6,8,9,10,12,15,16 })]
        [InlineData(new int[] { 5, 7, 5, 5, 22, 11, 33, 1, 4, 5 }, new int[] { 1, 4, 5,5,5,5, 7, 11, 22, 33 })]
        public void Sort(int[] array, int[] expectedResult)
        {
            QuickSortService.Sort(array, 0, array.Length - 1);
            for (int i = 0; i < array.Length; i++)
            {
                array[i].ShouldBe(expectedResult[i]);
            }
        }
    }
}