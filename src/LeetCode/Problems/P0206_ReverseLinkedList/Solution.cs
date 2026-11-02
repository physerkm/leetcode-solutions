namespace LeetCode.Problems.P0206_ReverseLinkedList;

// https://leetcode.com/problems/reverse-linked-list/
// Time: O(n), Space: O(1)

/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution
{
    public ListNode ReverseList(ListNode head)
    {
        ListNode prev = null;
        ListNode current = head;

        while (current != null)
        {
            ListNode next = current.next; // save the rest of the list
            current.next = prev;          // turn the arrow backwards
            prev = current;               // step forward
            current = next;
        }

        // current fell off the end; prev is the old last node, the new head.
        return prev;
    }
}
