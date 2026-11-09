using LeetCode.Problems.P0075_SortColors;

namespace LeetCode.Tests.Problems.P0075_SortColors;

public class SolutionTests
{
    [Theory]
    // LeetCode examples
    [InlineData(new[] { 2, 0, 2, 1, 1, 0 }, new[] { 0, 0, 1, 1, 2, 2 })]
    [InlineData(new[] { 2, 0, 1 }, new[] { 0, 1, 2 })]
    // A single color is already sorted
    [InlineData(new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 1 }, new[] { 1 })]
    [InlineData(new[] { 2 }, new[] { 2 })]
    // Already sorted, and fully reversed
    [InlineData(new[] { 0, 0, 1, 1, 2, 2 }, new[] { 0, 0, 1, 1, 2, 2 })]
    [InlineData(new[] { 2, 2, 1, 1, 0, 0 }, new[] { 0, 0, 1, 1, 2, 2 })]
    // Only one color
    [InlineData(new[] { 1, 1, 1 }, new[] { 1, 1, 1 })]
    // Only two colors: one of 0, 1, 2 is missing
    [InlineData(new[] { 1, 0, 1, 0 }, new[] { 0, 0, 1, 1 })]
    [InlineData(new[] { 2, 0, 2, 0 }, new[] { 0, 0, 2, 2 })]
    [InlineData(new[] { 2, 1, 2, 1 }, new[] { 1, 1, 2, 2 })]
    // The 0 starts last, behind a 2
    [InlineData(new[] { 2, 1, 0 }, new[] { 0, 1, 2 })]
    [InlineData(new[] { 2, 2, 0 }, new[] { 0, 2, 2 })]
    [InlineData(new[] { 1, 2, 0 }, new[] { 0, 1, 2 })]
    public void SortColors_SortsTheArrayInPlace(int[] nums, int[] expected)
    {
        new Solution().SortColors(nums);

        Assert.Equal(expected, nums);
    }

    [Fact]
    public void SortColors_SortsEveryArrayOfUpToSixColors()
    {
        // All 3 + 9 + 27 + 81 + 243 + 729 = 1092 arrays of length 1 to 6.
        for (int length = 1; length <= 6; length++)
        {
            int count = (int)Math.Pow(3, length);
            for (int code = 0; code < count; code++)
            {
                // Read code in base 3: each digit is one color.
                int[] nums = new int[length];
                for (int i = 0, rest = code; i < length; i++, rest /= 3)
                    nums[i] = rest % 3;

                int[] input = (int[])nums.Clone();
                int[] expected = nums.Order().ToArray();

                new Solution().SortColors(nums);

                Assert.True(expected.SequenceEqual(nums),
                    $"[{string.Join(", ", input)}] became [{string.Join(", ", nums)}], " +
                    $"expected [{string.Join(", ", expected)}]");
            }
        }
    }

    [Fact]
    public void SortColors_HandlesTheLongestAllowedArray()
    {
        // 300 colors (the most LeetCode allows) repeating 2, 1, 0.
        int[] nums = Enumerable.Range(0, 300).Select(i => 2 - i % 3).ToArray();

        new Solution().SortColors(nums);

        int[] expected = [.. Enumerable.Repeat(0, 100), .. Enumerable.Repeat(1, 100), .. Enumerable.Repeat(2, 100)];
        Assert.Equal(expected, nums);
    }
}
