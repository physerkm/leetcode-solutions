using LeetCode.Problems.P0151_ReverseWordsInAString;

namespace LeetCode.Tests.Problems.P0151_ReverseWordsInAString;

public class SolutionTests
{
    [Theory]
    // LeetCode examples
    [InlineData("the sky is blue", "blue is sky the")]
    [InlineData("  hello world  ", "world hello")]
    [InlineData("a good   example", "example good a")]
    // A single word comes back without the spaces around it
    [InlineData("a", "a")]
    [InlineData("hello", "hello")]
    [InlineData("   hello   ", "hello")]
    // Extra spaces only at the start, or only at the end
    [InlineData("   one two", "two one")]
    [InlineData("one two   ", "two one")]
    // Only the words swap; the letters inside a word keep their order
    [InlineData("abc def", "def abc")]
    // Upper-case letters and digits are part of words too
    [InlineData("LeetCode 151 Is Fun", "Fun Is 151 LeetCode")]
    // One-letter words with more and more spaces between them
    [InlineData(" a  b   c    d ", "d c b a")]
    public void ReverseWords_ReversesTheOrderOfTheWords(string s, string expected)
    {
        Assert.Equal(expected, new Solution().ReverseWords(s));
    }

    [Fact]
    public void ReverseWords_HandlesEveryShortMixOfLettersAndSpaces()
    {
        // Every string of length 1 to 7 made of 'a', 'b' and ' ' that has at least one word: 3,272 strings.
        char[] alphabet = { 'a', 'b', ' ' };
        for (int length = 1; length <= 7; length++)
        {
            int count = (int)Math.Pow(3, length);
            for (int code = 0; code < count; code++)
            {
                // Read code in base 3: each digit is one character.
                char[] chars = new char[length];
                for (int i = 0, rest = code; i < length; i++, rest /= 3)
                    chars[i] = alphabet[rest % 3];
                string s = new string(chars);

                if (string.IsNullOrWhiteSpace(s))
                    continue; // LeetCode always gives at least one word

                string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string expected = string.Join(" ", Enumerable.Reverse(words));
                string actual = new Solution().ReverseWords(s);

                Assert.True(expected == actual, $"\"{s}\" became \"{actual}\", expected \"{expected}\"");
            }
        }
    }

    [Fact]
    public void ReverseWords_HandlesALongString()
    {
        // The words 0, 1, ..., 1499 with two spaces between them and around them: 7,892 characters
        // (LeetCode allows up to 10,000).
        string[] words = Enumerable.Range(0, 1500).Select(i => i.ToString()).ToArray();
        string s = "  " + string.Join("  ", words) + "  ";

        string expected = string.Join(" ", Enumerable.Reverse(words));
        Assert.Equal(expected, new Solution().ReverseWords(s));
    }
}
