namespace LeetCode.Problems.P0075_SortColors;

// https://leetcode.com/problems/sort-colors/
// Time: O(n), Space: O(1)

public class Solution
{
    public void SortColors(int[] nums)
    {
        // The array is kept in four regions:
        //   [0, low)       0s
        //   [low, mid)     1s
        //   [mid, high]    not looked at yet
        //   (high, end]    2s
        int low = 0;
        int mid = 0;
        int high = nums.Length - 1;

        // Each turn either mid moves right or high moves left, so the loop runs exactly n times.
        while (mid <= high)
        {
            if (nums[mid] == 0)
            {
                // Swap the 0 to the end of the 0s. What comes back from low is a 1
                // (or this same 0 when low == mid), so both regions just grow by one.
                (nums[low], nums[mid]) = (nums[mid], nums[low]);
                low++;
                mid++;
            }
            else if (nums[mid] == 1)
            {
                // Already in the 1s region.
                mid++;
            }
            else
            {
                // Swap the 2 to the front of the 2s. What comes back from high has not been
                // looked at yet, so mid stays put and checks it next turn.
                (nums[mid], nums[high]) = (nums[high], nums[mid]);
                high--;
            }
        }
    }
}
