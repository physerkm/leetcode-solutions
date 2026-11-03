namespace LeetCode.Problems.P0238_ProductOfArrayExceptSelf;

// https://leetcode.com/problems/product-of-array-except-self/

public class Solution
{
    public int[] ProductExceptSelf(int[] nums)
    {
        // Çözümünü buraya yaz.
        int[] left = new int[nums.Length];
        int[] right = new int[nums.Length];
        int[] answer = new int[nums.Length];

        left[0] = 1;
        for (int i = 1; i < nums.Length; i++)
        {
            left[i] = left[i - 1] * nums[i - 1];
        }

        right[nums.Length - 1] = 1;
        for (int i = nums.Length - 2; i >= 0; i--)
        {
            right[i] = right[i + 1] * nums[i + 1];
        }

        foreach(var i in Enumerable.Range(0, nums.Length))
        {
            answer[i] = left[i] * right[i];
        }                               

        return answer;
    }
}
