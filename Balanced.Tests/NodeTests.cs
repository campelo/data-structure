using Shouldly;

namespace Balanced.Tests
{
    public class NodeTests
    {
        [Theory]
        [InlineData(new int[] { 3, 2, 4, 5 }, 6, new string[] { "2(BF=0) 3(BF=-1) 4(BF=0) 5(BF=0) 6(BF=0)", "3(BF=-1) 2(BF=0) 5(BF=0) 4(BF=0) 6(BF=0)" })]
        [InlineData(new int[] { 14, 25, 21, 10, 23, 7 ,26, 12, 30, 16 }, 19, new string[] { "7(BF=0) 10(BF=0) 12(BF=0) 14(BF=0) 16(BF=-1) 19(BF=0) 21(BF=0) 23(BF=0) 25(BF=-1) 26(BF=-1) 30(BF=0)", "21(BF=0) 14(BF=0) 10(BF=0) 7(BF=0) 12(BF=0) 16(BF=-1) 19(BF=0) 25(BF=-1) 23(BF=0) 26(BF=-1) 30(BF=0)" })]
        public void BalanceNode(int[] array, int newValue, string[] expectedResults)
        {
            Avl avl = new Avl(array);
            avl.Add(newValue);
            string result = avl.ShowTreeBF();
            expectedResults.ShouldContain(result);
        }
    }
}