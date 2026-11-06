using LeetCode.Problems.P0055_JumpGame;

namespace LeetCode.Tests.Problems.P0055_JumpGame;

public class SolutionTests
{
    [Theory]
    // LeetCode example: 0 → 1 → 4
    [InlineData(new[] { 2, 3, 1, 1, 4 })]
    // Already standing on the last index
    [InlineData(new[] { 0 })]
    [InlineData(new[] { 5 })]
    // The last value does not matter, even if it is 0
    [InlineData(new[] { 1, 0 })]
    [InlineData(new[] { 1, 1, 1, 1 })]
    // Jumping over zeros
    [InlineData(new[] { 2, 0, 0 })]
    [InlineData(new[] { 3, 0, 0, 0 })]
    [InlineData(new[] { 1, 2, 0, 1 })]
    // A jump may be shorter than the value, and it may go past the end
    [InlineData(new[] { 10, 0, 0 })]
    // Always taking the longest jump lands on a 0; a shorter first jump works: 0 → 1 → 4
    [InlineData(new[] { 2, 3, 0, 0, 1 })]
    public void CanJump_ReturnsTrueWhenTheLastIndexIsReachable(int[] nums)
    {
        Assert.True(new Solution().CanJump(nums));
    }

    [Theory]
    // LeetCode example: every path ends on index 3, whose value is 0
    [InlineData(new[] { 3, 2, 1, 0, 4 })]
    // Stuck at the start
    [InlineData(new[] { 0, 1 })]
    [InlineData(new[] { 0, 2, 3 })]
    // Stuck in the middle
    [InlineData(new[] { 1, 0, 1 })]
    [InlineData(new[] { 1, 1, 0, 1 })]
    [InlineData(new[] { 2, 0, 0, 1 })]
    [InlineData(new[] { 3, 0, 0, 0, 1 })]
    public void CanJump_ReturnsFalseWhenStuckBeforeTheEnd(int[] nums)
    {
        Assert.False(new Solution().CanJump(nums));
    }

    [Fact]
    public void CanJump_HandlesTheLongestArrayOfSmallSteps()
    {
        // 10,000 ones: the end is reached one step at a time.
        int[] nums = Enumerable.Repeat(1, 10_000).ToArray();

        Assert.True(new Solution().CanJump(nums));
    }

    [Fact]
    public void CanJump_HandlesTheLongestArrayWhenStuck()
    {
        // 9998, 9997, ..., 1, 0, 0: every index reaches exactly index 9998, whose value is 0.
        // Trying every possible path would take forever: there are about 2^9998 of them.
        int[] nums = Enumerable.Range(0, 10_000).Select(i => Math.Max(9_998 - i, 0)).ToArray();

        Assert.False(new Solution().CanJump(nums));
    }

    [Fact]
    public void CanJump_HandlesTheLargestValues()
    {
        // Values up to 100,000 jump far past the end of a 10,000-element array.
        int[] nums = Enumerable.Repeat(100_000, 10_000).ToArray();

        Assert.True(new Solution().CanJump(nums));
    }
}
