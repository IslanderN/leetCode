// 127. Word Ladder
// A transformation sequence from word beginWord to word endWord using a dictionary wordList is a sequence of words beginWord -> s1 -> s2 -> ... -> sk such that:

// Every adjacent pair of words differs by a single letter.
// Every si for 1 <= i <= k is in wordList. Note that beginWord does not need to be in wordList.
// sk == endWord
// Given two words, beginWord and endWord, and a dictionary wordList, return the number of words in the shortest transformation sequence from beginWord to endWord, or 0 if no such sequence exists.

 

// Example 1:

// Input: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]
// Output: 5
// Explanation: One shortest transformation sequence is "hit" -> "hot" -> "dot" -> "dog" -> cog", which is 5 words long.
// Example 2:

// Input: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log"]
// Output: 0
// Explanation: The endWord "cog" is not in wordList, therefore there is no valid transformation sequence.
 

// Constraints:

// 1 <= beginWord.length <= 10
// endWord.length == beginWord.length
// 1 <= wordList.length <= 5000
// wordList[i].length == beginWord.length
// beginWord, endWord, and wordList[i] consist of lowercase English letters.
// beginWord != endWord
// All the words in wordList are unique.
public class Solution {
    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if(!wordList.Contains(endWord)) return 0;

        var visited = new HashSet<string>();
        var combinations = 
            wordList
                .SelectMany(s => GetCombinations(s).Select(w => (w, s)))
                .GroupBy(p => p.Item1)
                .ToDictionary(g => g.Key, g => g.Select(p => p.Item2).ToList());

        var q = new Queue<(string, int)>();
        q.Enqueue((beginWord, 1));
        visited.Add(beginWord);

        while(q.Count > 0) {
            (var word, var level) = q.Dequeue();
            if(word == endWord) return level;

            foreach(var c in GetCombinations(word)) {
                if(combinations.TryGetValue(c, out var list)) {
                    foreach(var w in list) {
                        if(!visited.Contains(w)) {
                            q.Enqueue((w, level + 1));
                            visited.Add(w);
                        }
                    }
                }
            }

        }

        return 0;        
    }

    private IEnumerable<string> GetCombinations(string word) {
        return word.Select((_, i) => word.Remove(i, 1).Insert(i, "*"));
    }
}