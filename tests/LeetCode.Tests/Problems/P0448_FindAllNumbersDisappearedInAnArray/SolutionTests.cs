using LeetCode.Problems.P0448_FindAllNumbersDisappearedInAnArray;

namespace LeetCode.Tests.Problems.P0448_FindAllNumbersDisappearedInAnArray;

public class SolutionTests
{
    [Theory]
    // LeetCode examples
    [InlineData(new[] { 4, 3, 2, 7, 8, 2, 3, 1 }, new[] { 5, 6 })]
    [InlineData(new[] { 1, 1 }, new[] { 2 })]
    // Nothing missing
    [InlineData(new[] { 1 }, new int[0])]
    [InlineData(new[] { 2, 1 }, new int[0])]
    [InlineData(new[] { 3, 1, 2, 5, 4 }, new int[0])]
    // Missing at the start or at the end
    [InlineData(new[] { 2, 2 }, new[] { 1 })]
    [InlineData(new[] { 1, 2, 2 }, new[] { 3 })]
    // One number repeated, everything else missing
    [InlineData(new[] { 5, 5, 5, 5, 5 }, new[] { 1, 2, 3, 4 })]
    public void FindDisappearedNumbers_ReturnsMissingNumbersInOrder(int[] nums, int[] expected)
    {
        Assert.Equal(expected, new Solution().FindDisappearedNumbers(nums));
    }

    [Fact]
    public void FindDisappearedNumbers_HandlesTheLongestAllowedArray()
    {
        // 1..50000 each appear twice, so 50001..100000 are missing.
        const int n = 100_000;
        int[] nums = Enumerable.Range(0, n).Select(i => i / 2 + 1).ToArray();

        Assert.Equal(Enumerable.Range(50_001, 50_000), new Solution().FindDisappearedNumbers(nums));
    }
}
