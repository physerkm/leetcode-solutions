using LeetCode.Problems.P0155_MinStack;

namespace LeetCode.Tests.Problems.P0155_MinStack;

public class MinStackTests
{
    [Fact]
    public void LeetCodeExample()
    {
        var stack = new MinStack();
        stack.Push(-2);
        stack.Push(0);
        stack.Push(-3);

        Assert.Equal(-3, stack.GetMin());
        stack.Pop();
        Assert.Equal(0, stack.Top());
        Assert.Equal(-2, stack.GetMin());
    }

    [Fact]
    public void SingleElement_IsBothTopAndMin()
    {
        var stack = new MinStack();
        stack.Push(7);

        Assert.Equal(7, stack.Top());
        Assert.Equal(7, stack.GetMin());
    }

    [Fact]
    public void IncreasingPushes_MinStaysAtTheFirstValue()
    {
        var stack = new MinStack();
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);

        Assert.Equal(3, stack.Top());
        Assert.Equal(1, stack.GetMin());
        stack.Pop();
        Assert.Equal(1, stack.GetMin());
    }

    [Fact]
    public void DecreasingPushes_EachPopBringsBackTheOlderMin()
    {
        var stack = new MinStack();
        for (int val = 5; val >= 1; val--)
            stack.Push(val);

        // Stack from bottom to top: 5 4 3 2 1
        for (int expectedMin = 1; expectedMin <= 4; expectedMin++)
        {
            Assert.Equal(expectedMin, stack.GetMin());
            stack.Pop();
        }

        Assert.Equal(5, stack.GetMin());
    }

    [Fact]
    public void RepeatedMin_PoppingOneCopyKeepsTheMin()
    {
        var stack = new MinStack();
        stack.Push(2);
        stack.Push(3);
        stack.Push(2);

        Assert.Equal(2, stack.GetMin());
        stack.Pop(); // removes one of the two 2s
        Assert.Equal(2, stack.GetMin());
        stack.Pop();
        Assert.Equal(2, stack.GetMin());
    }

    [Fact]
    public void MinGoesUpAgain_AfterTheSmallestValueIsPopped()
    {
        var stack = new MinStack();
        stack.Push(3);
        stack.Push(-5);
        stack.Push(4);

        Assert.Equal(-5, stack.GetMin());
        stack.Pop();
        stack.Pop(); // -5 leaves
        Assert.Equal(3, stack.Top());
        Assert.Equal(3, stack.GetMin());
    }

    [Fact]
    public void EmptiedStack_StartsFresh()
    {
        var stack = new MinStack();
        stack.Push(1);
        stack.Pop();
        stack.Push(2);

        Assert.Equal(2, stack.Top());
        Assert.Equal(2, stack.GetMin());
    }

    [Fact]
    public void HandlesTheSmallestAndLargestInt()
    {
        var stack = new MinStack();
        stack.Push(int.MaxValue);
        stack.Push(int.MinValue);
        stack.Push(int.MaxValue);

        Assert.Equal(int.MaxValue, stack.Top());
        Assert.Equal(int.MinValue, stack.GetMin());
        stack.Pop();
        stack.Pop();
        Assert.Equal(int.MaxValue, stack.Top());
        Assert.Equal(int.MaxValue, stack.GetMin());
    }

    [Fact]
    public void MatchesASimpleReference_OnManyRandomOperations()
    {
        // LeetCode allows up to 30000 calls. A fixed seed makes every run identical.
        var random = new Random(155);
        var stack = new MinStack();
        var reference = new List<int>(); // the end of the list is the top of the stack

        for (int call = 0; call < 30_000; call++)
        {
            if (reference.Count == 0 || random.Next(3) > 0)
            {
                int val = random.Next(-50, 50); // small range so the same min repeats often
                stack.Push(val);
                reference.Add(val);
            }
            else
            {
                stack.Pop();
                reference.RemoveAt(reference.Count - 1);
            }

            if (reference.Count > 0)
            {
                Assert.Equal(reference[^1], stack.Top());
                Assert.Equal(reference.Min(), stack.GetMin());
            }
        }
    }
}
