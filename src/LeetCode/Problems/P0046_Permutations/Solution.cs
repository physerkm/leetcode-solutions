namespace LeetCode.Problems.P0046_Permutations;

// https://leetcode.com/problems/permutations/
// Time: O(n * n!), Space: O(n) not counting the output

public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        var result = new List<IList<int>>();
        var current = new List<int>();         // the permutation being built, one slot at a time
        bool[] used = new bool[nums.Length];   // used[i] is true while nums[i] is in current

        Backtrack(nums, used, current, result);
        return result;
    }

    private static void Backtrack(int[] nums, bool[] used, List<int> current, List<IList<int>> result)
    {
        // Every slot is filled. Save a copy: current keeps changing after this.
        if (current.Count == nums.Length)
        {
            result.Add(new List<int>(current));
            return;
        }

        // Try each number that is not in current yet for the next slot.
        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i]) continue;

            // Choose
            current.Add(nums[i]);
            used[i] = true;

            // Explore: fill the remaining slots.
            Backtrack(nums, used, current, result);

            // Undo, so the next number can take this slot.
            current.RemoveAt(current.Count - 1);
            used[i] = false;
        }
    }
}
