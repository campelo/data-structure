using Shouldly;

namespace Heap.Tests
{
    public class MinHeapTests
    {
        [Theory]
        [InlineData(new long[] { }, new long[] { })]
        [InlineData(new long[] { 494521015 }, new long[] { 494521015 })]
        [InlineData(new long[] { 10, 8 ,6,4,2 }, new long[] { 2,4,8,10,6 })]
        [InlineData(new long[] { 10, 30, 20, 35, 40, 32, 25 }, new long[] { 10, 30, 20, 35, 40, 32, 25 })]
        [InlineData(new long[] { 10, 30, 20, 35, 40, 32, 25, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new long[] { 1,2,3,7,8,6,4,10,30,40,9,32,20,25,5,35 })]
        public void Add(long[] input, long[] expectedResult)
        {
            MinHeap minHeap = new();
            foreach (int i in input)
                minHeap.Add(i);
            for (int i = 0; i < minHeap.Length; i++)
                minHeap.Array[i].ShouldBe(expectedResult[i]);
        }

        [Theory]
        [InlineData(new long[] { }, new long[] { })]
        [InlineData(new long[] { 10, 8, 6, 4, 2 }, new long[] { 4, 6, 8, 10 })]
        [InlineData(new long[] { 10, 30, 20, 35, 40, 32, 25 }, new long[] { 20,30,25,35,40,32 })]
        [InlineData(new long[] { 10, 30, 20, 35, 40, 32, 25, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, new long[] { 2,7,3,10,8,6,4,35,30,40,9,32,20,25,5 })]
        public void Pop(long[] input, long[] expectedResult)
        {
            MinHeap minHeap = new();
            foreach (int i in input)
                minHeap.Add(i);
            minHeap.Pop();
            for (int i = 0; i < minHeap.Length; i++)
                minHeap.Array[i].ShouldBe(expectedResult[i]);
        }

        [Fact]
        public void TestCase()
        {
            MinHeap minHeap = new();
            minHeap.Add(3);
            minHeap.Add(65);
            minHeap.Remove(65);
            minHeap.Minimum.ShouldBe(3);
            minHeap.Remove(3);
            minHeap.Add(7);
            minHeap.Minimum.ShouldBe(7);
            minHeap.Add(-1);
            minHeap.Minimum.ShouldBe(-1);
            minHeap.Remove(-1);
            minHeap.Minimum.ShouldBe(7);
            minHeap.Remove(7);
        }

        [Fact]
        public void TestCase2()
        {
            MinHeap minHeap = new();
            minHeap.Add(286789035);
            minHeap.Add(255653921);
            minHeap.Add(274310529);
            minHeap.Add(494521015);
            minHeap.Minimum.ShouldBe(255653921);
            minHeap.Remove(255653921);
            minHeap.Remove(286789035);
            minHeap.Minimum.ShouldBe(274310529);
            minHeap.Add(236295092);
            minHeap.Add(254828111);
            minHeap.Remove(254828111);
            minHeap.Add(465995753);
            minHeap.Add(85886315);
            minHeap.Add(7959587);
            minHeap.Add(20842598);
            minHeap.Remove(7959587);
            minHeap.Minimum.ShouldBe(20842598);
            minHeap.Add(-51159108);
            minHeap.Minimum.ShouldBe(-51159108);
            minHeap.Remove(-51159108);
            minHeap.Minimum.ShouldBe(20842598);
            minHeap.Add(789534713);
        }

        [Theory]
        [InlineData(new long[] { }, 0)]
        [InlineData(new long[] { 10, 8, 6, 4, 2 }, 2)]
        [InlineData(new long[] { 10, 30, 20, 35, 40, 32, 25 }, 10)]
        [InlineData(new long[] { 10, 30, 20, 35, 40, 32, 25, 9, 8, 7, 6, 5, 4, 3, 2, 1 }, 1)]
        public void Minimum(long[] input, int expectedResult)
        {
            MinHeap minHeap = new();
            foreach (int i in input)
                minHeap.Add(i);
            minHeap.Minimum.ShouldBe(expectedResult);
        }
    }
}