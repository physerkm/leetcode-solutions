namespace LeetCode.Problems.P0002_AddTwoNumbers;

// https://leetcode.com/problems/add-two-numbers/
// Time: O(max(m, n)), Space: O(1) extra (the returned list does not count)

public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        // The lists start with the ones digit, so walking them from the head
        // is column addition from right to left.
        ListNode dummy = new ListNode(); // placeholder in front of the result, so the first digit needs no special case
        ListNode tail = dummy;           // last node of the result so far
        int carry = 0;

        // Keep going while a list has digits left or a carry still has to be written.
        while (l1 != null || l2 != null || carry != 0)
        {
            int sum = carry;

            // A list that has run out adds nothing, as if its digit were 0.
            if (l1 != null)
            {
                sum += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
            }

            // sum is at most 9 + 9 + 1 = 19: write its ones digit, carry the rest (0 or 1).
            tail.next = new ListNode(sum % 10);
            tail = tail.next;
            carry = sum / 10;
        }

        return dummy.next;
    }
}
