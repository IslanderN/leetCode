// 632. Smallest Range Covering Elements from K Lists
// You have k lists of sorted integers in non-decreasing order. Find the smallest range that includes at least one number from each of the k lists.

// We define the range [a, b] is smaller than range [c, d] if b - a < d - c or a < c if b - a == d - c.

 

// Example 1:

// Input: nums = [[4,10,15,24,26],[0,9,12,20],[5,18,22,30]]
// Output: [20,24]
// Explanation: 
// List 1: [4, 10, 15, 24,26], 24 is in range [20,24].
// List 2: [0, 9, 12, 20], 20 is in range [20,24].
// List 3: [5, 18, 22, 30], 22 is in range [20,24].
// Example 2:

// Input: nums = [[1,2,3],[1,2,3],[1,2,3]]
// Output: [1,1]
 

// Constraints:

// nums.length == k
// 1 <= k <= 3500
// 1 <= nums[i].length <= 50
// -105 <= nums[i][j] <= 105
// nums[i] is sorted in non-decreasing order.


public class Solution {
    public int[] SmallestRange(IList<IList<int>> nums) {
        var left = 0;
        var right = Int32.Max;
        var mins = PriorityQueue<int, int>();
        var next = new int[nums.Count];

        var min = 0; var max = Int32.Max;
        for(int i = 0; i < nums.Count; i++) {
            mins.Enqueue(i, nums[i][0]);
            max = Math.Max(max, nums[i][0]);
        }

        bool end = false;
        while(!end) {
            var i = mins.Dequeue();
            min = nums[i][next[i]];

            if(max - min < right - left) {
                left = min;
                right = max;
            }
            next[i]++;

            if(next[i] >= nums[i].Count) end = true;

            var n = nums[i][next[i]];
            mins.Enqueue(i, n);
            max = Math.Max(max, n);
        }
        
        return new int[] {left, right};
    }
}