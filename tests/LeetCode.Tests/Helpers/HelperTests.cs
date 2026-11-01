namespace LeetCode.Tests.Helpers;

public class HelperTests
{
    [Theory]
    [InlineData(new int[0])]
    [InlineData(new[] { 1 })]
    [InlineData(new[] { 1, 2, 3 })]
    public void ListNode_RoundTrips(int[] values)
    {
        Assert.Equal(values, ListNodeHelper.ToArray(ListNodeHelper.FromArray(values)));
    }

    [Fact]
    public void TreeNode_RoundTrips()
    {
        int?[] values = { 1, null, 2, 3 };

        var root = TreeNodeHelper.FromLevelOrder(values);

        Assert.Null(root.left);
        Assert.Equal(2, root.right.val);
        Assert.Equal(3, root.right.left.val);
        Assert.Equal(values, TreeNodeHelper.ToLevelOrder(root));
    }

    [Fact]
    public void TreeNode_EmptyTree()
    {
        Assert.Null(TreeNodeHelper.FromLevelOrder());
        Assert.Empty(TreeNodeHelper.ToLevelOrder(null));
    }
}
