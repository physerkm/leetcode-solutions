namespace LeetCode.Problems.P0020_ValidParentheses;

// https://leetcode.com/problems/valid-parentheses/
// Time: O(n), Space: O(n)
public class Solution
{
    public bool IsValid(string s)
    {
        var stack = new Stack<char>();

        foreach (char c in s)
        {
            if (c == '(' || c == '[' || c == '{')
            {
                // Opening bracket: remember it until it gets closed.
                stack.Push(c);
            }
            else
            {
                // Closing bracket with nothing open.
                if (stack.Count == 0)
                    return false;

                // It must close the most recently opened bracket.
                char open = stack.Pop();

                if (c == ')' && open != '(') return false;
                if (c == ']' && open != '[') return false;
                if (c == '}' && open != '{') return false;
            }
        }

        // Anything left was opened but never closed.
        return stack.Count == 0;
    }
}
