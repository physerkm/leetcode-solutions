using LeetCode.Problems.P0074_SearchA2DMatrix;

namespace LeetCode.Tests.Problems.P0074_SearchA2DMatrix;

public class SolutionTests
{
    private static readonly int[][] Example =
    {
        new[] { 1, 3, 5, 7 },
        new[] { 10, 11, 16, 20 },
        new[] { 23, 30, 34, 60 },
    };

    // Jagged arrays can't go in [InlineData], so the cases live here.
    public static TheoryData<int[][], int, bool> Cases => new()
    {
        // LeetCode examples
        { Example, 3, true },
        { Example, 13, false },

        // First, last and row-boundary cells
        { Example, 1, true },
        { Example, 60, true },
        { Example, 7, true },
        { Example, 10, true },

        // Outside the range of the matrix
        { Example, 0, false },
        { Example, 61, false },

        // Tiny shapes
        { new[] { new[] { 1 } }, 1, true },
        { new[] { new[] { 1 } }, 2, false },
        { new[] { new[] { 1, 3 } }, 3, true },
        { new[] { new[] { 1 }, new[] { 3 } }, 3, true },

        // Negative numbers
        { new[] { new[] { -5, -3 }, new[] { -1, 0 } }, -3, true },
        { new[] { new[] { -5, -3 }, new[] { -1, 0 } }, -2, false },
    };

    [Theory]
    [MemberData(nameof(Cases))]
    public void SearchMatrix_ReturnsWhetherTargetExists(int[][] matrix, int target, bool expected)
    {
        Assert.Equal(expected, new Solution().SearchMatrix(matrix, target));
    }
}
