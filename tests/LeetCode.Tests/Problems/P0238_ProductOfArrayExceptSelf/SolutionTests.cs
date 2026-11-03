using LeetCode.Problems.P0238_ProductOfArrayExceptSelf;

namespace LeetCode.Tests.Problems.P0238_ProductOfArrayExceptSelf;

public class SolutionTests
{
    [Theory]
    // LeetCode examples
    [InlineData(new[] { 1, 2, 3, 4 }, new[] { 24, 12, 8, 6 })]
    [InlineData(new[] { -1, 1, 0, -3, 3 }, new[] { 0, 0, 9, 0, 0 })]
    // Shortest allowed input
    [InlineData(new[] { 2, 3 }, new[] { 3, 2 })]
    [InlineData(new[] { 5, 0 }, new[] { 0, 5 })]
    // One zero: only the zero's own slot is non-zero (dividing by the total breaks here)
    [InlineData(new[] { 1, 0, 3 }, new[] { 0, 3, 0 })]
    // Two zeros: every slot still sees at least one zero
    [InlineData(new[] { 0, 4, 0 }, new[] { 0, 0, 0 })]
    // Negative numbers
    [InlineData(new[] { -2, -3, 4 }, new[] { -12, -8, 6 })]
    [InlineData(new[] { 1, 1, 1, 1 }, new[] { 1, 1, 1, 1 })]
    public void ProductExceptSelf_ReturnsProductOfAllOtherNumbers(int[] nums, int[] expected)
    {
        Assert.Equal(expected, new Solution().ProductExceptSelf(nums));
    }

    [Fact]
    public void ProductExceptSelf_HandlesTheLongestAllowedArray()
    {
        // All ones except a 2 at the start and a 3 at the end.
        const int n = 100_000;
        int[] nums = Enumerable.Repeat(1, n).ToArray();
        nums[0] = 2;
        nums[n - 1] = 3;

        int[] expected = Enumerable.Repeat(6, n).ToArray();
        expected[0] = 3;
        expected[n - 1] = 2;

        Assert.Equal(expected, new Solution().ProductExceptSelf(nums));
    }
}
