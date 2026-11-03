namespace LeetCode.Problems.P0128_LongestConsecutiveSequence;

// https://leetcode.com/problems/longest-consecutive-sequence/

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        // Çözümünü buraya yaz.
        if (nums.Length == 0)
            return 0;

        Array.Sort(nums);

        int longest = 1;
        int current = 1;

        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] == nums[i - 1] + 1)
            {
                current++;
            }
            else if (nums[i] == nums[i - 1])
            {
                
            }
            else
            {
                current = 1;
            }
            
            longest = Math.Max(longest, current);
        }

        return longest;
    }
}
