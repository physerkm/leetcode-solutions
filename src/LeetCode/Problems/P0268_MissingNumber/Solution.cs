namespace LeetCode.Problems.P0268_MissingNumber;

// https://leetcode.com/problems/missing-number/
// Time: O(n), Space: O(1)

public class Solution
{
    public int MissingNumber(int[] nums)
    {
        // nums holds the numbers 0..n with exactly one left out, so n is the array's length.
        int n = nums.Length;

        // With nothing missing the sum would be 0 + 1 + ... + n = n * (n + 1) / 2.
        // n is at most 10,000, so this is at most 50,005,000 and fits in an int.
        int expectedSum = n * (n + 1) / 2;

        int actualSum = 0;
        foreach (int num in nums)
        {
            actualSum += num;
        }

        // Every other number is in both sums and cancels out; only the missing one is left.
        return expectedSum - actualSum;
    }
}
