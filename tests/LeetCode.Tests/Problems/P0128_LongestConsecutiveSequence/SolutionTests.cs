using LeetCode.Problems.P0128_LongestConsecutiveSequence;

namespace LeetCode.Tests.Problems.P0128_LongestConsecutiveSequence;

public class SolutionTests
{
    [Theory]
    // LeetCode examples
    [InlineData(new[] { 100, 4, 200, 1, 3, 2 }, 4)]
    [InlineData(new[] { 0, 3, 7, 2, 5, 8, 4, 6, 0, 1 }, 9)]
    [InlineData(new[] { 1, 0, 1, 2 }, 3)]
    // Empty and single
    [InlineData(new int[0], 0)]
    [InlineData(new[] { 5 }, 1)]
    // Duplicates count once
    [InlineData(new[] { 1, 1, 1 }, 1)]
    [InlineData(new[] { 1, 2, 2, 3 }, 3)]
    // Nothing consecutive
    [InlineData(new[] { 10, 5, 20 }, 1)]
    // Negative numbers and zero
    [InlineData(new[] { -1, -2, 0, 1 }, 4)]
    // Two runs: the longer one wins
    [InlineData(new[] { 1, 2, 3, 10, 11, 12, 13 }, 4)]
    [InlineData(new[] { 9, 1, 4, 7, 3, -1, 0, 5, 8, -1, 6 }, 7)]
    // Edges of the allowed range
    [InlineData(new[] { 1_000_000_000, -1_000_000_000 }, 1)]
    [InlineData(new[] { 999_999_999, 1_000_000_000 }, 2)]
    public void LongestConsecutive_ReturnsLengthOfLongestRun(int[] nums, int expected)
    {
        Assert.Equal(expected, new Solution().LongestConsecutive(nums));
    }

    [Fact]
    public void LongestConsecutive_HandlesTheLongestAllowedArray()
    {
        // 0..99999 in a scrambled order (7919 shares no factor with 100000, so every number appears once).
        const int n = 100_000;
        int[] nums = Enumerable.Range(0, n).Select(i => (int)((long)i * 7919 % n)).ToArray();

        Assert.Equal(n, new Solution().LongestConsecutive(nums));
    }
}
