namespace LeetCode.Problems.P0046_Permutations;

// https://leetcode.com/problems/permutations/

public class Solution
{
    public IList<IList<int>> Permute(int[] nums)
    {
        // Çözümünü buraya yaz.
        var result = new List<IList<int>>();
        var current = new List<int>();
        bool[] used = new bool[nums.Length];

        Backtrack(nums, used, current, result);
        return result;
    }

    private void Backtrack(int[] nums, bool[] used, List<int> current, List<IList<int>> result)
    {
        if (current.Count == nums.Length)
        {
            result.Add(new List<int>(current));

            return;
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (used[i]) continue;

            current.Add(nums[i]);
            used[i] = true;

            Backtrack(nums, used, current, result);

            current.RemoveAt(current.Count - 1);
            used[i] = false;
        }
    }
}
