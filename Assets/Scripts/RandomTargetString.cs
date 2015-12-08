using System;
using UnityEngine;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomTargetString : MonoBehaviour
{

    public int numberOfWordsPerString = 5;

    private List<string> _wordList = new List<string>();
    private Text _targetText;

    // Use this for initialization
	void Awake ()
	{	    	  
	    GenerateWordList();

	    _targetText = GetComponent<Text>();
        _targetText.text = GenerateRandomString(numberOfWordsPerString);
	}

    private void GenerateWordList()
    {
        var words = Resources.Load<TextAsset>("Words");
        _wordList = words.text.Split('\n').ToList();
    }

    string GenerateRandomString(int targetWordCount)
    {
        var randomWords = new List<string>(targetWordCount);
        string randomString = null;

        for (var i = 0; i < targetWordCount; i++)        
            randomWords.Add(_wordList [Random.Range(0, _wordList.Count)]);

        for (int index = 0; index < randomWords.Count; index++)
        {
            var randomWord = randomWords[index];

            if (index == randomWords.Count)  //Start without a space
            {
                if (randomString != null) randomString += randomWord.Substring(0, randomString.Length - 1);
            }
            else                                       
                randomString += (randomWord + " ");
        }

        return System.Text.RegularExpressions.Regex.Replace(randomString, @"\s+", " ");	//Make sure the random string is all single spaced;                
    }

    public Text TargetText
    {
        get { return _targetText; }
    }
}
