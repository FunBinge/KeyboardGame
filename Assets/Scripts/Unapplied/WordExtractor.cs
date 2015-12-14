using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

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

    public string GenerateRandomString(int wordCount, int characterLimit)
    {
        var randomWords = GenerateRandomWords(wordCount);
        var randomString = string.Join(" ", randomWords.ToArray());

        if (randomString.Length > characterLimit)
        {
            randomString = randomString.Substring(0, characterLimit).Trim();
            int index = randomString.LastIndexOf(" ", StringComparison.Ordinal);
            randomString = randomString.Substring(0, index);
        }

        return randomString;
    }
}