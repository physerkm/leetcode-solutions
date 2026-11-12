using LeetCode.Problems.P0046_Permutations;

namespace LeetCode.Tests.Problems.P0046_Permutations;

public class SolutionTests
{
    // LeetCode accepts the permutations in any order, so the tests sort them first.
    // Each permutation becomes text like "1,2,3" so a failing test prints it readably.
    private static string[] Sorted(IList<IList<int>> result) =>
        result.Select(p => string.Join(",", p)).Order(StringComparer.Ordinal).ToArray();

    [Fact]
    public void Permute_LeetCodeExample1()
    {
        IList<IList<int>> result = new Solution().Permute(new[] { 1, 2, 3 });

        Assert.Equal(new[] { "1,2,3", "1,3,2", "2,1,3", "2,3,1", "3,1,2", "3,2,1" }, Sorted(result));
    }

    [Fact]
    public void Permute_LeetCodeExample2()
    {
        IList<IList<int>> result = new Solution().Permute(new[] { 0, 1 });

        Assert.Equal(new[] { "0,1", "1,0" }, Sorted(result));
    }

    [Fact]
    public void Permute_LeetCodeExample3()
    {
        IList<IList<int>> result = new Solution().Permute(new[] { 1 });

        Assert.Equal(new[] { "1" }, Sorted(result));
    }

    [Theory]
    // One number
    [InlineData(new[] { 5 })]
    [InlineData(new[] { -10 })]
    // Negative numbers, and the smallest and largest values LeetCode allows
    [InlineData(new[] { -1, 1 })]
    [InlineData(new[] { 3, -10, 10 })]
    // Longer arrays, not in sorted order
    [InlineData(new[] { 2, 0, 3, 1 })]
    [InlineData(new[] { 4, -3, 2, -1, 0 })]
    // The longest array LeetCode allows: 6 numbers, 720 permutations
    [InlineData(new[] { 1, 2, 3, 4, 5, 6 })]
    [InlineData(new[] { -10, 7, -5, 0, 10, 5 })]
    public void Permute_ReturnsEveryOrderExactlyOnce(int[] nums)
    {
        IList<IList<int>> result = new Solution().Permute(nums);

        // n numbers can be ordered in n! = 1 × 2 × ... × n ways.
        int factorial = Enumerable.Range(1, nums.Length).Aggregate(1, (product, k) => product * k);
        Assert.Equal(factorial, result.Count);

        // Each permutation uses every number of nums exactly once.
        int[] sortedNums = nums.Order().ToArray();
        foreach (IList<int> permutation in result)
            Assert.Equal(sortedNums, permutation.Order().ToArray());

        // No permutation appears twice. With the count above, that means none is missing either.
        string[] all = Sorted(result);
        Assert.Equal(all.Length, all.Distinct().Count());
    }
}
