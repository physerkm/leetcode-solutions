namespace LeetCode.Problems.P0155_MinStack;

// https://leetcode.com/problems/min-stack/

public class MinStack
{
    private Stack<int> stack;
    private Stack<int> mins;

    public MinStack()
    {
        // Çözümünü buraya yaz.
        stack = new Stack<int>();
        mins = new Stack<int>();
    }

    public void Push(int val)
    {
        // Çözümünü buraya yaz.
        stack.Push(val);
        if (mins.Count == 0)
        {
            mins.Push(val);
        }
        else
        {
            int smaller = Math.Min(val, mins.Peek());
            mins.Push(smaller);
        }
    }

    public void Pop()
    {
        // Çözümünü buraya yaz.
        stack.Pop();
        mins.Pop();
    }

    public int Top()
    {
        // Çözümünü buraya yaz.
        return stack.Peek();
    }

    public int GetMin()
    {
        // Çözümünü buraya yaz.
        return mins.Peek();
    }
}
