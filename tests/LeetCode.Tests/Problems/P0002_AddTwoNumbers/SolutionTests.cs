using LeetCode.Problems.P0002_AddTwoNumbers;
using LeetCode.Tests.Helpers;

namespace LeetCode.Tests.Problems.P0002_AddTwoNumbers;

public class SolutionTests
{
    [Theory]
    // LeetCode examples: 342 + 465 = 807, 0 + 0 = 0, 9999999 + 9999 = 10009998
    [InlineData(new[] { 2, 4, 3 }, new[] { 5, 6, 4 }, new[] { 7, 0, 8 })]
    [InlineData(new[] { 0 }, new[] { 0 }, new[] { 0 })]
    [InlineData(new[] { 9, 9, 9, 9, 9, 9, 9 }, new[] { 9, 9, 9, 9 }, new[] { 8, 9, 9, 9, 0, 0, 0, 1 })]
    // No carry
    [InlineData(new[] { 1 }, new[] { 2 }, new[] { 3 })]
    // The last carry becomes a new digit: 5 + 5 = 10
    [InlineData(new[] { 5 }, new[] { 5 }, new[] { 0, 1 })]
    // Different lengths, in both orders: 81 + 0 = 81
    [InlineData(new[] { 1, 8 }, new[] { 0 }, new[] { 1, 8 })]
    [InlineData(new[] { 0 }, new[] { 1, 8 }, new[] { 1, 8 })]
    // A carry that runs through the rest of the longer list: 1 + 999 = 1000
    [InlineData(new[] { 1 }, new[] { 9, 9, 9 }, new[] { 0, 0, 0, 1 })]
    [InlineData(new[] { 9, 9, 9 }, new[] { 1 }, new[] { 0, 0, 0, 1 })]
    // 942 + 9465 = 10407
    [InlineData(new[] { 2, 4, 9 }, new[] { 5, 6, 4, 9 }, new[] { 7, 0, 4, 0, 1 })]
    public void AddTwoNumbers_ReturnsTheSumWithDigitsInReverseOrder(int[] first, int[] second, int[] expected)
    {
        var l1 = ListNodeHelper.FromArray(first);
        var l2 = ListNodeHelper.FromArray(second);

        var result = new Solution().AddTwoNumbers(l1, l2);

        Assert.Equal(expected, ListNodeHelper.ToArray(result));
    }

    [Fact]
    public void AddTwoNumbers_HandlesNumbersTooBigForLong()
    {
        // LeetCode allows 100 digits; long holds only about 19.
        // 999...9 (100 nines) + 1 = 1000...0 (a 1 followed by 100 zeros).
        var l1 = ListNodeHelper.FromArray(Enumerable.Repeat(9, 100).ToArray());
        var l2 = ListNodeHelper.FromArray(1);
        var expected = Enumerable.Repeat(0, 100).Append(1).ToArray();

        var result = new Solution().AddTwoNumbers(l1, l2);

        Assert.Equal(expected, ListNodeHelper.ToArray(result));
    }

    [Fact]
    public void AddTwoNumbers_HandlesTheLongestListsWithACarryAtEveryDigit()
    {
        // 999...9 + 999...9 (100 nines each) = 1999...98: written in reverse, 8, then 99 nines, then 1.
        var nines = Enumerable.Repeat(9, 100).ToArray();
        var expected = new[] { 8 }.Concat(Enumerable.Repeat(9, 99)).Append(1).ToArray();

        var result = new Solution().AddTwoNumbers(ListNodeHelper.FromArray(nines), ListNodeHelper.FromArray(nines));

        Assert.Equal(expected, ListNodeHelper.ToArray(result));
    }
}
