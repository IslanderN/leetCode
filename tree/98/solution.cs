// 98. Validate Binary Search Tree
// Given the root of a binary tree, determine if it is a valid binary search tree (BST).

// A valid BST is defined as follows:

// The left subtree of a node contains only nodes with keys less than the node's key.
// The right subtree of a node contains only nodes with keys greater than the node's key.
// Both the left and right subtrees must also be binary search trees.
 

// Example 1:


// Input: root = [2,1,3]
// Output: true
// Example 2:


// Input: root = [5,1,4,null,null,3,6]
// Output: false
// Explanation: The root node's value is 5 but its right child's value is 4.
 

// Constraints:

// The number of nodes in the tree is in the range [1, 104].
// -231 <= Node.val <= 231 - 1


/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
public class Solution {
    public bool IsValidBST(TreeNode root) {
        var stack = new Stack<(TreeNode, int?, int?)>(); // node, low limit, max limit
        stack.Push((root, null, null));

        while(stack.Any()) {
            var (node, min, max) = stack.Pop();

            if( (min.HasValue && node.val <= min.Value) || (max.HasValue && node.val >= max.Value)) {
                return false;
            }

            if(node.right != null) {
                stack.Push((node.right, node.val, max));
            }
            if(node.left != null) {
                stack.Push((node.left, min, node.val));
            }
        }

        return true;
        
    }
}