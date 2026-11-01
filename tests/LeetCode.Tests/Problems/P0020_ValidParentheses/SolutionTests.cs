using LeetCode.Problems.P0020_ValidParentheses;

namespace LeetCode.Tests.Problems.P0020_ValidParentheses;

public class SolutionTests
{
    [Theory]
    // LeetCode examples
    [InlineData("()", true)]
    [InlineData("()[]{}", true)]
    [InlineData("(]", false)]
    [InlineData("([])", true)]
    [InlineData("([)]", false)]
    // Nested and side by side
    [InlineData("{[]}", true)]
    [InlineData("((()))", true)]
    [InlineData("([]{})[]", true)]
    // Closing bracket with nothing open
    [InlineData(")", false)]
    [InlineData("]()", false)]
    [InlineData("())", false)]
    // Opened but never closed
    [InlineData("(", false)]
    [InlineData("((", false)]
    [InlineData("(()", false)]
    // Wrong order
    [InlineData("){", false)]
    [InlineData("[(])", false)]
    public void IsValid_ReturnsWhetherBracketsAreBalanced(string s, bool expected)
    {
        Assert.Equal(expected, new Solution().IsValid(s));
    }
}
