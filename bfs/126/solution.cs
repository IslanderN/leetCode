// 126. Word Ladder II
// A transformation sequence from word beginWord to word endWord using a dictionary wordList is a sequence of words beginWord -> s1 -> s2 -> ... -> sk such that:

// Every adjacent pair of words differs by a single letter.
// Every si for 1 <= i <= k is in wordList. Note that beginWord does not need to be in wordList.
// sk == endWord
// Given two words, beginWord and endWord, and a dictionary wordList, return all the shortest transformation sequences from beginWord to endWord, or an empty list if no such sequence exists. Each sequence should be returned as a list of the words [beginWord, s1, s2, ..., sk].

 

// Example 1:

// Input: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log","cog"]
// Output: [["hit","hot","dot","dog","cog"],["hit","hot","lot","log","cog"]]
// Explanation: There are 2 shortest transformation sequences:
// "hit" -> "hot" -> "dot" -> "dog" -> "cog"
// "hit" -> "hot" -> "lot" -> "log" -> "cog"
// Example 2:

// Input: beginWord = "hit", endWord = "cog", wordList = ["hot","dot","dog","lot","log"]
// Output: []
// Explanation: The endWord "cog" is not in wordList, therefore there is no valid transformation sequence.
 

// Constraints:

// 1 <= beginWord.length <= 5
// endWord.length == beginWord.length
// 1 <= wordList.length <= 500
// wordList[i].length == beginWord.length
// beginWord, endWord, and wordList[i] consist of lowercase English letters.
// beginWord != endWord
// All the words in wordList are unique.
// The sum of all shortest transformation sequences does not exceed 105.



public class Solution {

    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
        var words = new HashSet<string>(wordList);

        var layers = fillLayers(beginWord, endWord, words);

        var pathes = new List<IList<string>>();
        var currentPath = new List<string>{endWord};

        buildPathes(layers, endWord, beginWord, currentPath, pathes);

        for(int i = 0; i < pathes.Count; i++){
            pathes[i] = pathes[i].Reverse().ToList();
        }

        return pathes;        
    }

    private void buildPathes(Dictionary<string, List<string>> layers, string source, string destination, List<string> path, IList<IList<string>> all) {
        if(source == destination) {
            all.Add(new List<string>(path));
            return;
        }
        if(layers.TryGetValue(source, out var layer))
        {
            foreach(var word in layer) {
                path.Add(word);
                buildPathes(layers, word, destination, path, all);
                path.RemoveAt(path.Count - 1);
            }
        }
    }

    private Dictionary<string, List<string>> fillLayers(string beginWord, string endWord, HashSet<string> words) {
        var layers = new Dictionary<string, List<string>>();
        var q = new Queue<string>();
        q.Enqueue(beginWord);

        if(words.Contains(beginWord)) words.Remove(beginWord);

        var visited = new HashSet<string>();
        
        while(q.Count() > 0) {
            var wordsToDelete = new List<string>();

            for(int i = q.Count() - 1; i >= 0; i--) {
                var currentWord = q.Dequeue();

                var neighbours = findNeighbours(currentWord, words);

                foreach(var n in neighbours) {
                    wordsToDelete.Add(n);

                    List<string> list = null;
                    if(!layers.TryGetValue(n, out list)) list = new List<string>();

                    list.Add(currentWord);
                    layers[n] = list;

                    if(!visited.Contains(n)){
                        q.Enqueue(n);
                        visited.Add(n);
                    }
                }
            }

            wordsToDelete.ForEach(w => words.Remove(w));
        }

        return layers;
    }

    private List<string> findNeighbours(string word, HashSet<string> words) {
        var array = word.ToCharArray();
        var list = new List<string>();
        for(int i = 0; i < array.Length; i++) {
            var oldChar = array[i];

            for(char n = 'a'; n <= 'z'; n++) {
                if(n != oldChar) {
                    array[i] = n;
                    var newWord = new String(array);
                    if(words.Contains(newWord)) {
                        list.Add(newWord);
                    }
                }
            }
            array[i] = oldChar;
        }
        return list;
    }
}
  