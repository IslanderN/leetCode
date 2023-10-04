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
        var l = 0; var r = 0;


        for(int i = 0; i < s.Length; i++) {
            var oddLength = check(i, i, s);
            if(oddLength > r - l + 1) {
                var diff = oddLength / 2;
                l = i - diff;
                r = i + diff;
            }

            var evenLength = check(i, i + 1, s);
            if(evenLength > r - l + 1) {
                var diff = (evenLength / 2) - 1;
                l = i - diff;
                r = i + 1 + diff;
            }
        }

        return s.Substring(l, r - l + 1);        
    }

    private int check(int left, int right, string s) {
        while(left >= 0 && right < s.Length && s[left] == s[right]) {
            left--;
            right++;
        }

        return right - left - 1;
    }
}