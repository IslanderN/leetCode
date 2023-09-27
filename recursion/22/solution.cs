// 22. Generate Parentheses
// Given n pairs of parentheses, write a function to generate all combinations of well-formed parentheses.

 

// Example 1:

// Input: n = 3
// Output: ["((()))","(()())","(())()","()(())","()()()"]
// Example 2:

// Input: n = 1
// Output: ["()"]
 

// Constraints:

// 1 <= n <= 8


public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        var answers = new List<string>();
        G(answers, new StringBuilder(2*n), 0, 0, n);
        return answers;
    }

    private void G(List<string> ans, StringBuilder s, int left, int right, int n){
        if(s.Length == 2 * n) {
            ans.Add(s.ToString());
        }

        if(left <= right && left < n) {
            s.Append("(");
            G(ans, s, left + 1, right, n);
            s.Remove(s.Length - 1, 1);
        }
        else {
            if (left < n) {
                s.Append("(");
                G(ans, s, left + 1, right, n);
                s.Remove(s.Length - 1, 1);
            }

            s.Append(")");
            G(ans, s, left, right + 1, n);
            s.Remove(s.Length - 1, 1);
        }
    }
}