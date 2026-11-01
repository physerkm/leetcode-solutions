using LeetCode.Problems.P0001_TwoSum;

namespace LeetCode.Tests.Problems.P0001_TwoSum;

public class SolutionTests
{
    [Theory]
    [InlineData(new[] { 2, 7, 11, 15 }, 9, new[] { 0, 1 })]
    [InlineData(new[] { 3, 2, 4 }, 6, new[] { 1, 2 })]
    [InlineData(new[] { 3, 3 }, 6, new[] { 0, 1 })]
    public void TwoSum_ReturnsIndicesOfThePair(int[] nums, int target, int[] expected)
    {
        var result = new Solution().TwoSum(nums, target);

        // LeetCode accepts the indices in any order.
        Array.Sort(result);
        Assert.Equal(expected, result);
    }
}
