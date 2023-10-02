// 3. Longest Substring Without Repeating Characters
// Given a string s, find the length of the longest substring without repeating characters.

 

// Example 1:

// Input: s = "abcabcbb"
// Output: 3
// Explanation: The answer is "abc", with the length of 3.
// Example 2:

// Input: s = "bbbbb"
// Output: 1
// Explanation: The answer is "b", with the length of 1.
// Example 3:

// Input: s = "pwwkew"
// Output: 3
// Explanation: The answer is "wke", with the length of 3.
// Notice that the answer must be a substring, "pwke" is a subsequence and not a substring.
 

// Constraints:

// 0 <= s.length <= 5 * 104
// s consists of English letters, digits, symbols and spaces.

public class Solution {
    public int LengthOfLongestSubstring(string s) {
        var map = new Dictionary<char, int>();

        int right = 0;
        int left = 0;
        int largest = 0;
        int dupl = 0;

        while(right < s.Length) {
            var c = s[right];
            var number = getOrDefault(map, c, 0);
            number++;
            map[c] = number;

            if(number > 1) {
                dupl++;
                largest = Math.Max(largest, right - left);
            }

            while(dupl > 0) {
                var cl = s[left];
                var num = map[cl];
                num--;
                map[cl] = num;

                if(num == 1) dupl--;
                left++;
            }

            right++;
        }
        if(dupl == 0) {
            largest = Math.Max(largest, right - left);
        }

        return largest;

    }

    private int getOrDefault(Dictionary<char, int> d, char c, int def) {
        if(d.ContainsKey(c)) return d[c];
        else {
            d[c] = def;
            return def;
        }
    }
}