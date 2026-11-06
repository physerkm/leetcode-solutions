using LeetCode.Problems.P0268_MissingNumber;

namespace LeetCode.Tests.Problems.P0268_MissingNumber;

public class SolutionTests
{
    [Theory]
    // LeetCode examples
    [InlineData(new[] { 3, 0, 1 }, 2)]
    [InlineData(new[] { 0, 1 }, 2)]
    [InlineData(new[] { 9, 6, 4, 2, 3, 5, 7, 0, 1 }, 8)]
    // Single number: either 0 or 1 is missing
    [InlineData(new[] { 0 }, 1)]
    [InlineData(new[] { 1 }, 0)]
    // 0 is missing
    [InlineData(new[] { 2, 1 }, 0)]
    [InlineData(new[] { 3, 1, 2 }, 0)]
    // n is missing: nothing is out of place, the range just ends early
    [InlineData(new[] { 1, 0 }, 2)]
    [InlineData(new[] { 2, 0, 1 }, 3)]
    // Missing in the middle
    [InlineData(new[] { 2, 0 }, 1)]
    [InlineData(new[] { 4, 0, 1, 3 }, 2)]
    public void MissingNumber_ReturnsTheNumberNotInTheArray(int[] nums, int expected)
    {
        Assert.Equal(expected, new Solution().MissingNumber(nums));
    }

    [Fact]
    public void MissingNumber_FindsEachPossibleMissingNumber()
    {
        // For 0..10, take each number out in turn and shuffle the rest.
        const int n = 10;
        for (int missing = 0; missing <= n; missing++)
        {
            int[] nums = Enumerable.Range(0, n + 1)
                .Where(x => x != missing)
                .OrderBy(x => x * 7 % (n + 1))
                .ToArray();

            Assert.Equal(missing, new Solution().MissingNumber(nums));
        }
    }

    [Fact]
    public void MissingNumber_HandlesTheLongestAllowedArray()
    {
        // 0..10000 without 6789, in a scrambled order (7919 shares no factor with 10001).
        const int n = 10_000;
        int[] nums = Enumerable.Range(0, n + 1)
            .Select(i => (int)((long)i * 7919 % (n + 1)))
            .Where(x => x != 6789)
            .ToArray();

        Assert.Equal(6789, new Solution().MissingNumber(nums));
    }
}
