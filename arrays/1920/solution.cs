// Given a zero-based permutation nums (0-indexed), 
// build an array ans of the same length where ans[i] = nums[nums[i]] for each 0 <= i < nums.length and return it.
// A zero-based permutation nums is an array of distinct integers from 0 to nums.length - 1 (inclusive).

// Example
// Input: nums = [0,2,1,5,3,4]
// Output: [0,1,2,4,5,3]
// Explanation: The array ans is built as follows: 
// ans = [nums[nums[0]], nums[nums[1]], nums[nums[2]], nums[nums[3]], nums[nums[4]], nums[nums[5]]]
//     = [nums[0], nums[2], nums[1], nums[5], nums[3], nums[4]]
//     = [0,1,2,4,5,3]

public class Solution {
    private IEnumerable<int> YieldedArray(int[] nums)
    {
        for(int i = 0; i < nums.Length; i++)
        {
            yield return nums[nums[i]];
        }
    }
    public int[] BuildArray(int[] nums) {
        return YieldedArray(nums).ToArray();
        
    }
}

