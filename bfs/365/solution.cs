// 365.Water and Jug Problem
// You are given two jugs with capacities jug1Capacity and jug2Capacity liters. There is an infinite amount of water supply available. Determine whether it is possible to measure exactly targetCapacity liters using these two jugs.

// If targetCapacity liters of water are measurable, you must have targetCapacity liters of water contained within one or both buckets by the end.

// Operations allowed:

// Fill any of the jugs with water.
// Empty any of the jugs.
// Pour water from one jug into another till the other jug is completely full, or the first jug itself is empty.
 

// Example 1:

// Input: jug1Capacity = 3, jug2Capacity = 5, targetCapacity = 4
// Output: true
// Explanation: The famous Die Hard example 
// Example 2:

// Input: jug1Capacity = 2, jug2Capacity = 6, targetCapacity = 5
// Output: false
// Example 3:

// Input: jug1Capacity = 1, jug2Capacity = 2, targetCapacity = 3
// Output: true



// Constraints:

// 1 <= jug1Capacity, jug2Capacity, targetCapacity <= 106

public class Solution {
    public bool CanMeasureWater(int j1, int j2, int targetCapacity) {
        var t = j1 + j2;
        if(t < targetCapacity) return false;

        var set = new HashSet<int>();
        var q = new Queue<int>();
        var directions = new int[] { j1, -j1, j2, -j2 };

        q.Enqueue(0);
        set.Add(0);

        while(q.Count > 0) {
            var c = q.Dequeue();
            if(c == targetCapacity) return true;
            
            foreach(var d in directions) {
                var x = d + c;
                if(x > 0 && x <= t && (!set.Contains(x))) {
                    q.Enqueue(x);
                    set.Add(x);
                }
            }
        }
        return false;

        
    }
}