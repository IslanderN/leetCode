// Design a class to find the kth largest element in a stream. Note that it is the kth largest element in the sorted order, not the kth distinct element.

// Implement KthLargest class:

// KthLargest(int k, int[] nums) Initializes the object with the integer k and the stream of integers nums.
// int add(int val) Appends the integer val to the stream and returns the element representing the kth largest element in the stream.
 

// Example 1:

// Input
// ["KthLargest", "add", "add", "add", "add", "add"]
// [[3, [4, 5, 8, 2]], [3], [5], [10], [9], [4]]
// Output
// [null, 4, 5, 5, 8, 8]

// Explanation
// KthLargest kthLargest = new KthLargest(3, [4, 5, 8, 2]);
// kthLargest.add(3);   // return 4
// kthLargest.add(5);   // return 5
// kthLargest.add(10);  // return 5
// kthLargest.add(9);   // return 8
// kthLargest.add(4);   // return 8
 

// Constraints:

// 1 <= k <= 104
// 0 <= nums.length <= 104
// -104 <= nums[i] <= 104
// -104 <= val <= 104
// At most 104 calls will be made to add.
// It is guaranteed that there will be at least k elements in the array when you search for the kth element.

using System.Collections.Generic;

public class KthLargest {
    internal class Node : IComparable<Node>
    {
        public int Value { get; set; }
        public int Count { get; set; } = 1;

        public int CompareTo(Node other)
        {
            return this.Value.CompareTo(other.Value);
        }

    }

    private int K;
    private SortedSet<Node> tree = new SortedSet<Node>();
    

    public KthLargest(int k, int[] nums) {
        this.K = k;
        Init(nums);        
    }
    
    public int Add(int val) {
        InsertElement(val);
        var node = FindKthNode();
        return node.Value;
    }

    private void InsertElement(int value)
    {
        var node = new Node {Value = value};
        if(tree.TryGetValue(node, out var foundNode))
        {
            foundNode.Count++;
        }
        else
        {
            tree.Add(node);
        }
    }

    private Node FindKthNode()
    {
        var k = this.K;
        Node node = null;
        foreach( var el in tree.Reverse() )
        {
            k -= el.Count;
            if (k <= 0)
            {
                node = el;
                break;
            }
        }
        return node;
    }
    private void Init(int[] nums)
    {
        foreach(var i in nums)
        {
            InsertElement(i);
        }
    }
}

/**
 * Your KthLargest object will be instantiated and called as such:
 * KthLargest obj = new KthLargest(k, nums);
 * int param_1 = obj.Add(val);
 */