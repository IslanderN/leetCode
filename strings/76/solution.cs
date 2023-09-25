// 76. Minimum Window Substring

// Given two strings s and t of lengths m and n respectively, return the minimum window substring of s such that every character in t (including duplicates) is included in the window. If there is no such substring, return the empty string "".

// The testcases will be generated such that the answer is unique.

 

// Example 1:

// Input: s = "ADOBECODEBANC", t = "ABC"
// Output: "BANC"
// Explanation: The minimum window substring "BANC" includes 'A', 'B', and 'C' from string t.
// Example 2:

// Input: s = "a", t = "a"
// Output: "a"
// Explanation: The entire string s is the minimum window.
// Example 3:

// Input: s = "a", t = "aa"
// Output: ""
// Explanation: Both 'a's from t must be included in the window.
// Since the largest window of s only has one 'a', return empty string.
 

// Constraints:

// m == s.length
// n == t.length
// 1 <= m, n <= 105
// s and t consist of uppercase and lowercase English letters.
 

// Follow up: Could you find an algorithm that runs in O(m + n) time?


public class Solution {
    public string MinWindow(string s, string t) {
        var requiredChars = new Dictionary<char, int>();
        foreach(var c in t) {
            requiredChars.TryGetValue(c, out var count);
            requiredChars[c] = count + 1;
        }

        var requiredCount = requiredChars.Count();
        var windowChars = new Dictionary<char, int>();
        var l = 0; var r = 0;
        var actualCount = 0;
        var answer = new int[]{-1, 0, 0};

        while(r < s.Length) {
            var c = s[r];
            
            windowChars.TryGetValue(c, out var count);
            count++;
            windowChars[c] = count;

            if(requiredChars.ContainsKey(c) && requiredChars[c] == count) actualCount++;

            while(l <= r && actualCount == requiredCount) {
                if(answer[0] == -1 || answer[0] > (r - l + 1)) {
                    answer[0] = r - l + 1;
                    answer[1] = l;
                    answer[2] = r;
                }

                c = s[l];
                count = windowChars[c];
                count--;
                windowChars[c] = count;

                if(requiredChars.ContainsKey(c) && count < requiredChars[c]) actualCount--;

                l++;
            } 

            r++;
        }

        return answer[0] == -1 ? string.Empty : s.Substring(answer[1], (answer[2] - answer[1] + 1)); 
    }
}