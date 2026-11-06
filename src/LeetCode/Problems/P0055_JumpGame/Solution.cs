namespace LeetCode.Problems.P0055_JumpGame;

// https://leetcode.com/problems/jump-game/

public class Solution
{
    public bool CanJump(int[] nums)
    {
        // Çözümünü buraya yaz.
        int farthest = 0;
        for (int i = 0; i < nums.Length; i++)
        {
            if (i > farthest)
            {
                return false;
            }
            int x = i + nums[i];
            farthest = Math.Max(x, farthest);
            if (farthest >= nums.Length - 1)
            {
                return true;
            }
        }

        return false;
    }
}
