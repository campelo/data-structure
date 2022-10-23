using Shouldly;

namespace Huffman.Tests;

public class HuffmanServiceTests
{
    [Theory]
    [InlineData("aababcabcd","1101101001101001000")]
    public void Huffman_Encode(string input, string expectedResult)
    {
        var result = new HuffmanService(input).Encode();
        result.ShouldBe(expectedResult);
    }

    [Theory]
    [InlineData("1101101001101001000", "aababcabcd")]
    public void Huffman_Decode(string encodedText, string expectedResult)
    {
        var result = new HuffmanService(expectedResult).Decode(encodedText);
        result.ShouldBe(expectedResult);
    }
}