using LeetCode.Problems.P0070_ClimbingStairs;

namespace LeetCode.Tests.Problems.P0070_ClimbingStairs;

public class SolutionTests
{
    [Theory]
    // LeetCode examples
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    // Smallest input
    [InlineData(1, 1)]
    // Small enough to count by hand
    [InlineData(4, 5)]
    [InlineData(5, 8)]
    // Larger inputs
    [InlineData(10, 89)]
    [InlineData(20, 10946)]
    // Largest allowed input: a solution that tries every path one by one takes seconds here.
    [InlineData(45, 1836311903)]
    public void ClimbStairs_ReturnsNumberOfDistinctWays(int n, int expected)
    {
        Assert.Equal(expected, new Solution().ClimbStairs(n));
    }
}
