namespace LeetCode.Problems.P0151_ReverseWordsInAString;

// https://leetcode.com/problems/reverse-words-in-a-string/

public class Solution
{
    public string ReverseWords(string s)
    {
        // Çözümünü buraya yaz.
        string[] words = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(words);

        return string.Join(" ", words);
    }
}
