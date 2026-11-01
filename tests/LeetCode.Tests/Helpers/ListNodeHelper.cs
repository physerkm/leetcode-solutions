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

    public static int[] ToArray(ListNode head)
    {
        var result = new List<int>();

        for (var node = head; node != null; node = node.next)
            result.Add(node.val);

        return result.ToArray();
    }
}
