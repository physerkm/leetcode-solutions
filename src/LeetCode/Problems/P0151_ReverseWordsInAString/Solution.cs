namespace LeetCode.Problems.P0151_ReverseWordsInAString;

// https://leetcode.com/problems/reverse-words-in-a-string/
// Time: O(n), Space: O(n)

public class Solution
{
    public string ReverseWords(string s)
    {
        // Cut at every space. A run of spaces leaves empty pieces ("") between them; drop those.
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // Reverse the word order in place: the first word swaps with the last, and so on inward.
        Array.Reverse(words);

        // Exactly one space between words, none at the start or the end.
        return string.Join(" ", words);
    }
}
