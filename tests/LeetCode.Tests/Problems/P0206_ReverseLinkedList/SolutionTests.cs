using LeetCode.Problems.P0206_ReverseLinkedList;
using LeetCode.Tests.Helpers;

namespace LeetCode.Tests.Problems.P0206_ReverseLinkedList;

public class SolutionTests
{
    [Theory]
    // LeetCode examples
    [InlineData(new[] { 1, 2, 3, 4, 5 }, new[] { 5, 4, 3, 2, 1 })]
    [InlineData(new[] { 1, 2 }, new[] { 2, 1 })]
    [InlineData(new int[0], new int[0])]
    // Single node
    [InlineData(new[] { 7 }, new[] { 7 })]
    // Odd length, duplicates, negatives and limits
    [InlineData(new[] { 1, 2, 3 }, new[] { 3, 2, 1 })]
    [InlineData(new[] { 1, 1, 2 }, new[] { 2, 1, 1 })]
    [InlineData(new[] { -5000, 0, 5000 }, new[] { 5000, 0, -5000 })]
    public void ReverseList_ReturnsNodesInReverseOrder(int[] values, int[] expected)
    {
        var head = ListNodeHelper.FromArray(values);

        var result = new Solution().ReverseList(head);

        Assert.Equal(expected, ListNodeHelper.ToArray(result));
    }

    [Fact]
    public void ReverseList_HandlesTheLongestAllowedList()
    {
        // LeetCode allows up to 5000 nodes.
        var head = ListNodeHelper.FromArray(Enumerable.Range(1, 5000).ToArray());
        var expected = Enumerable.Range(1, 5000).Reverse().ToArray();

        var result = new Solution().ReverseList(head);

        Assert.Equal(expected, ListNodeHelper.ToArray(result));
    }
}
