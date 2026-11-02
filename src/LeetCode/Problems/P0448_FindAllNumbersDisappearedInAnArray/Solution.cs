namespace LeetCode.Problems.P0448_FindAllNumbersDisappearedInAnArray;

// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/
// Time: O(n), Space: O(1) extra (the returned list does not count)

public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        // Every number x in 1..n has its own box: nums[x - 1].
        // Seeing x marks its box by making the value there negative.
        foreach (int num in nums)
        {
            int box = Math.Abs(num) - 1; // num may already be negative from an earlier mark
            if (nums[box] > 0)
                nums[box] = -nums[box];
        }

        // A box that stayed positive belongs to a number that never appeared.
        List<int> result = new List<int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] > 0)
                result.Add(i + 1);
            else
                nums[i] = -nums[i]; // undo the mark so the caller gets its array back unchanged
        }

        return result;
    }
}
