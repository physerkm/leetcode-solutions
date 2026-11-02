namespace LeetCode.Problems.P0448_FindAllNumbersDisappearedInAnArray;

// https://leetcode.com/problems/find-all-numbers-disappeared-in-an-array/

public class Solution
{
    public IList<int> FindDisappearedNumbers(int[] nums)
    {
        bool[] seen = new bool[nums.Length + 1];
        foreach (int num in nums)
        {
            seen[num] = true;
        }

        List<int> result = new List<int>();

        for (int i = 1; i < seen.Length; i++)
        {
            if (!seen[i])
            {
                result.Add(i);
            }
        }

        return result;
    }
}
