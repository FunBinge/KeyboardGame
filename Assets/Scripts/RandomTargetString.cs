using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RandomTargetString : MonoBehaviour
{

    public int numberOfWordsPerString = 5;
    public StringJudge stringJudge;

    private List<string> _wordList = new List<string>();
    private Text _targetText;
    private int _characterLimit = 0;
    private string _randomString;

    public int TargetStringLength
    {
        get { return _randomString.Length; }
    }

    // Use this for initialization
    void Awake ()
	{
	    _targetText = GetComponent<Text>();
        _characterLimit = CalculateCharacterLimit();
        GenerateWordList();        
        DisplayNewRandomLine();                
    }

    void OnEnable()
    {
        KeyboardInputString.OnInputStringEdited += delegate {
            _targetText.text = StringJudge.CompareStringToTargetString(KeyboardInputString.InputString, _randomString);
        };
        LineSubmitter.OnSubmittedSuccessfully += DisplayNewRandomLine;
    }

    void OnDisable()
    {
        LineSubmitter.OnSubmittedSuccessfully -= DisplayNewRandomLine;
    }

    public void DisplayNewRandomLine()
    {
        Debug.Log("DisplayNewRandomLine (RandomTargetString)");
        var randomWords = GenerateRandomWords(numberOfWordsPerString);
        _randomString = string.Join(" ", randomWords.ToArray());

        if (_randomString.Length > _characterLimit)        
            _randomString = _randomString.Substring(0, _characterLimit).Trim();
        
        
        _targetText.text = _randomString;

    }

    private int CalculateCharacterLimit()
    {
        TextGenerator _textGenerator = _targetText.cachedTextGenerator;
        _textGenerator.Populate(_targetText.text, _targetText.GetGenerationSettings(_targetText.rectTransform.rect.size));

        int visibleChars = _textGenerator.characterCountVisible;
        return visibleChars;
    }

    private void GenerateWordList()
    {
        var words = Resources.Load<TextAsset>("Words");
        _wordList = words.text.Split('\n').Select(w => w.Trim()).ToList();
    }

    private List<string> GenerateRandomWords(int targetWordCount)
    {
        var randomWords = new List<string>(targetWordCount);

        for (var i = 0; i < targetWordCount; i++)
            randomWords.Add(_wordList[Random.Range(0, _wordList.Count)]);

        return randomWords;
    }
}
