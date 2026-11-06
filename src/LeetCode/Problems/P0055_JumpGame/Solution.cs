namespace LeetCode.Problems.P0055_JumpGame;

// https://leetcode.com/problems/jump-game/
// Time: O(n), Space: O(1)

public class Solution
{
    public bool CanJump(int[] nums)
    {
        int lastIndex = nums.Length - 1;
        int farthest = 0; // every index from 0 to farthest can be reached

        for (int i = 0; i < nums.Length; i++)
        {
            // i is past every index we can reach, so we are stuck before the end.
            if (i > farthest)
                return false;

            // From i we can land anywhere up to i + nums[i]: a jump may be shorter than nums[i].
            int reach = i + nums[i];
            farthest = Math.Max(farthest, reach);

            // The last index is in reach, so the rest of the array does not matter.
            if (farthest >= lastIndex)
                return true;
        }

        // Only an empty array gets here. LeetCode gives at least one element, and then
        // the loop's last turn always returns. C# still needs a return at the end.
        return false;
    }
}
