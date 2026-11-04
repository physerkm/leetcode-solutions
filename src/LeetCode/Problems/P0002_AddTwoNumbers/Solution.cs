namespace LeetCode.Problems.P0002_AddTwoNumbers;

// https://leetcode.com/problems/add-two-numbers/

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummy = new ListNode();
        ListNode tail = dummy;
        int carry = 0;

        while (l1 != null || l2 != null || carry != 0)
        {
            int x = 0;
            if (l1 != null)
            {
                x = l1.val;
                l1 = l1.next;
            }

            int y = 0;
            if (l2 != null)
            {
                y = l2.val;
                l2 = l2.next;
            }

            int sum = x + y + carry;

            int digit = sum % 10;            

            tail.next = new ListNode(digit);

            carry = sum / 10;

            tail = tail.next;
        }

        return dummy.next;
    }
}
