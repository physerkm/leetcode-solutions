namespace LeetCode.Problems.P0074_SearchA2DMatrix;

// https://leetcode.com/problems/search-a-2d-matrix/
// Time: O(log(m * n)), Space: O(1)
public class Solution
{
    public bool SearchMatrix(int[][] matrix, int target)
    {
        int rows = matrix.Length;
        int cols = matrix[0].Length;

        // Treat the matrix as one sorted array of rows * cols elements.
        int left = 0;
        int right = rows * cols - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int value = matrix[mid / cols][mid % cols];

            if (value == target)
                return true;

            if (value < target)
                left = mid + 1;
            else
                right = mid - 1;
        }

        return false;
    }
}
