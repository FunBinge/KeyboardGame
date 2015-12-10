using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordExtractor
{    
    private readonly List<string> _wordList;

    public WordExtractor (TextAsset textAsset)
    {
        _wordList = textAsset.text.Split('\n').Select(w => w.Trim()).ToList();
    }

    public List<string> GenerateRandomWords(int targetWordCount)
    {
        var randomWords = new List<string>(targetWordCount);

        for (var i = 0; i < targetWordCount; i++)
            randomWords.Add(_wordList[Random.Range(0, _wordList.Count)]);

        return randomWords;
    }
}