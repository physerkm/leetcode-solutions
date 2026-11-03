namespace LeetCode.Problems.P0128_LongestConsecutiveSequence;

// https://leetcode.com/problems/longest-consecutive-sequence/
// Time: O(n), Space: O(n)

public class Solution
{
    public int LongestConsecutive(int[] nums)
    {
        // Duplicates collapse, and "is x here?" becomes an O(1) lookup.
        HashSet<int> set = new HashSet<int>(nums);
        int longest = 0;

        // Loop over the set, not nums: a run start repeated many times is then counted once.
        foreach (int num in set)
        {
            // num - 1 is present, so num is inside a run that its real start will count.
            if (set.Contains(num - 1))
                continue;

            int length = 1;
            while (set.Contains(num + length))
                length++;

            longest = Math.Max(longest, length);
        }

        return longest;
    }
}
