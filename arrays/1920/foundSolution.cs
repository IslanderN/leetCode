
public class Solution {
    public int[] BuildArray(int[] nums) 
    {
        var length = nums.Length;
        for(int i = 0; i < length; i++)
        {
            nums[i] += (nums[nums[i]] % length) * length;
        }
        for(int i = 0; i < length; i++)
        {
            nums[i] /= length;
        }        
        return nums;
    }
}
