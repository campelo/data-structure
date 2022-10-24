using Shouldly;

namespace HashTable.Tests;

public class HashTableServiceTests
{
    [Theory]
    [InlineData(7, "ive got a lovely bunch of coconuts", "ive got some coconuts", false)]
    [InlineData(6, "give me one grand today night", "give one grand today", true)]
    [InlineData(6, "two times three is not four", "two times two is four", false)]
    public void HasAllWords(int max, string mainText, string text, bool expectedResult)
    {
        HashTableService ht = new HashTableService(max);
        ht.AddWordsFromText(mainText);
        ht.HasAllWords(text).ShouldBe(expectedResult);
    }
}