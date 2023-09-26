// 20. Valid Parentheses
// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.

// An input string is valid if:

// Open brackets must be closed by the same type of brackets.
// Open brackets must be closed in the correct order.
// Every close bracket has a corresponding open bracket of the same type.
 

// Example 1:

// Input: s = "()"
// Output: true
// Example 2:

// Input: s = "()[]{}"
// Output: true
// Example 3:

// Input: s = "(]"
// Output: false
 

// Constraints:

// 1 <= s.length <= 104
// s consists of parentheses only '()[]{}'.

public class Solution {
    public bool IsValid(string s) {
        var stack = new Stack<char>();
        var opened = new char[]{ '(', '{', '['};
        var closed = new char[]{ ')', '}', ']'};
        
        for(int i = 0; i < s.Length; i++) {
            if(opened.Contains(s[i])) {
                stack.Push(s[i]);
            }
            else {
                if(stack.Count() == 0) return false;

                var op = stack.Pop();
                var opIndex = Array.IndexOf(opened, op);
                var clIndex = Array.IndexOf(closed, s[i]);

                if(opIndex != clIndex) return false;
            }
        }

        return stack.Count() == 0;
    }
}