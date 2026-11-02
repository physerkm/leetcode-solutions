namespace LeetCode.Tests.Helpers;

// Converts between LeetCode's array notation ([1,2,3]) and linked lists.
public static class ListNodeHelper
{
    public static ListNode FromArray(params int[] values)
    {
        var dummy = new ListNode();
        var tail = dummy;

        foreach (var value in values)
        {
            tail.next = new ListNode(value);
            tail = tail.next;
        }

        return dummy.next;
    }

    // Throws if the list loops back on itself, so a buggy solution fails the test instead of hanging it.
    public static int[] ToArray(ListNode head)
    {
        var result = new List<int>();
        var seen = new HashSet<ListNode>();

        for (var node = head; node != null; node = node.next)
        {
            if (!seen.Add(node))
                throw new InvalidOperationException($"The list has a cycle: node {node.val} is visited twice.");

            result.Add(node.val);
        }

        return result.ToArray();
    }
}
