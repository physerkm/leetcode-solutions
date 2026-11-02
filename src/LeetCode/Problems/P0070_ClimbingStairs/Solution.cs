namespace LeetCode.Problems.P0070_ClimbingStairs;

// https://leetcode.com/problems/climbing-stairs/
// Time: O(n), Space: O(1)

public class Solution
{
    public int ClimbStairs(int n)
    {
        // 1 step: one way (1). 2 steps: two ways (1+1, 2).
        if (n <= 2)
            return n;

        int twoBelow = 1; // ways to reach step 1
        int oneBelow = 2; // ways to reach step 2

        for (int step = 3; step <= n; step++)
        {
            // The last move came either from one step below or from two steps below.
            int ways = oneBelow + twoBelow;

            // Slide both up by one step for the next round.
            twoBelow = oneBelow;
            oneBelow = ways;
        }

        return oneBelow;
    }
}
