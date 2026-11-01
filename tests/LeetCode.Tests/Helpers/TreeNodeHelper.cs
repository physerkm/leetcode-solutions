namespace LeetCode.Tests.Helpers;

// Converts between LeetCode's level-order notation ([1,null,2,3]) and binary trees.
public static class TreeNodeHelper
{
    public static TreeNode FromLevelOrder(params int?[] values)
    {
        if (values.Length == 0 || values[0] is null)
            return null;

        var root = new TreeNode(values[0].Value);
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        int i = 1;

        while (queue.Count > 0 && i < values.Length)
        {
            var node = queue.Dequeue();

            if (values[i] is int left)
            {
                node.left = new TreeNode(left);
                queue.Enqueue(node.left);
            }
            i++;

            if (i < values.Length && values[i] is int right)
            {
                node.right = new TreeNode(right);
                queue.Enqueue(node.right);
            }
            i++;
        }

        return root;
    }

    public static int?[] ToLevelOrder(TreeNode root)
    {
        var result = new List<int?>();
        var queue = new Queue<TreeNode>();
        queue.Enqueue(root);

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            if (node == null)
            {
                result.Add(null);
                continue;
            }

            result.Add(node.val);
            queue.Enqueue(node.left);
            queue.Enqueue(node.right);
        }

        // LeetCode drops trailing nulls: [1,null,2] not [1,null,2,null,null].
        while (result.Count > 0 && result[^1] == null)
            result.RemoveAt(result.Count - 1);

        return result.ToArray();
    }
}
