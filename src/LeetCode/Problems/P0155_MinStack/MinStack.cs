namespace LeetCode.Problems.P0155_MinStack;

// https://leetcode.com/problems/min-stack/
// Time: O(1) per operation, Space: O(n)

public class MinStack
{
    // Two stacks that always have the same height. values holds the pushed numbers;
    // each entry in mins is the smallest value at or below the same level,
    // so the top of mins is always the current minimum.
    private readonly Stack<int> values;
    private readonly Stack<int> mins;

    public MinStack()
    {
        values = new Stack<int>();
        mins = new Stack<int>();
    }

    public void Push(int val)
    {
        values.Push(val);

        // The minimum up to this level is val or the minimum below it, whichever is smaller.
        if (mins.Count == 0)
            mins.Push(val);
        else
            mins.Push(Math.Min(val, mins.Peek()));
    }

    public void Pop()
    {
        // Popping both puts the level below back on top, along with the minimum
        // that was recorded when it was pushed. Nothing has to be searched.
        values.Pop();
        mins.Pop();
    }

    public int Top()
    {
        return values.Peek();
    }

    public int GetMin()
    {
        return mins.Peek();
    }
}
