namespace LeetCode.Problems.P0268_MissingNumber;

// https://leetcode.com/problems/missing-number/

public class Solution
{
    public int MissingNumber(int[] nums)
    {
        // Çözümünü buraya yaz.
        int sum = 0;
        int n = nums.Length;
        int expectedSum = n * (n+1) / 2;

        foreach (int num in nums)
        {
            sum = sum + num;
        }       
        
        return expectedSum - sum;
    }
}
