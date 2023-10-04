// 5. Longest Palindromic Substring
// Given a string s, return the longest palindromic substring in s.

// Example 1:

// Input: s = "babad"
// Output: "bab"
// Explanation: "aba" is also a valid answer.
// Example 2:

// Input: s = "cbbd"
// Output: "bb"
 

// Constraints:

// 1 <= s.length <= 1000
// s consist of only digits and English letters.

public class Solution {
    public string LongestPalindrome(string s) {
        var n = s.Length;
        var ans = new int[]{0, 0};
        var dp = new bool[n, n];

        for(int i = 0; i < n; i++) {
            dp[i, i] = true;
            if(i != n - 1) {
                if(s[i]==s[i + 1]){
                    dp[i, i+1] = true;
                    ans[0] = i;
                    ans[1] = i + 1;
                }
            }
        }

        for(int diff = 2; diff < n; diff++) {
            for(int i = 0; i < n - diff; i++) {
                int j = i + diff;
                if(s[i] == s[j] && dp[i + 1, j - 1]) {
                    dp[i,j] = true;
                    ans[0] = i;
                    ans[1] = j;
                }
            }
        }

        return s.Substring(ans[0], ans[1] - ans[0] + 1);        
    }
}