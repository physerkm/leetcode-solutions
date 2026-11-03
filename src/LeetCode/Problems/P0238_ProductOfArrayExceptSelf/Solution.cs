namespace LeetCode.Problems.P0238_ProductOfArrayExceptSelf;

// https://leetcode.com/problems/product-of-array-except-self/
// Time: O(n), Space: O(1) extra (the returned array does not count)

public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        int n = nums.Length;
        int[] answer = new int[n];

        // Left to right: answer[i] = product of everything left of i.
        answer[0] = 1;
        for (int i = 1; i < n; i++)
            answer[i] = answer[i - 1] * nums[i - 1];

        // Right to left: `right` is the product of everything right of i.
        int right = 1;
        for (int i = n - 1; i >= 0; i--)
        {
            answer[i] *= right;
            right *= nums[i];
        }

        return answer;
    }
}
