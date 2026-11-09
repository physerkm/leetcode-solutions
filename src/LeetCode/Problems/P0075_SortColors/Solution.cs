namespace LeetCode.Problems.P0075_SortColors;

// https://leetcode.com/problems/sort-colors/

public class Solution
{
    public void SortColors(int[] nums)
    {
        // Çözümünü buraya yaz.
        int[] sayac = new int[3];
        foreach(int num in nums)
        {
            sayac[num]++;
        }   
        int yer = 0;
        for (int i = 0; i < sayac[0]; i++)
        {
            nums[yer] = 0;
            yer++;            
        }    
        for (int i = 0; i < sayac[1]; i++)
        {
            nums[yer] = 1;
            yer++;            
        }     
        for (int i = 0; i < sayac[2]; i++)
        {
            nums[yer] = 2;
            yer++;            
        }      
    }
}
