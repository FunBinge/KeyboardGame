using System;
using UnityEngine;
using UnityEngine.UI;

public class TargetTextString : MonoBehaviour
{
    
    public int wordCount = 5;    

    private WordExtractor _wordExtractor;
    private Text _targetTextDisplay;
    private int _characterLimit = 0;
    private static string _randomString;

    public static string TargetString {
        get { return _randomString; }
    }

    public int TargetStringLength
    {
        get { return _randomString.Length; }
    }

    // Use this for initialization
    void Awake ()
	{
        _wordExtractor = new WordExtractor(Resources.Load<TextAsset>("Words"));
	    _targetTextDisplay = GetComponent<Text>();
        _characterLimit = CalculateCharacterLimit();              
        DisplayNewRandomLine();                
    }

    void OnEnable()
    {
        KeyboardInputString.OnInputStringEdited += DisplayFeedbackString;
        LineSubmitter.OnSubmittedSuccessfully += DisplayNewRandomLine;
    }

    void OnDisable()
    {
        KeyboardInputString.OnInputStringEdited -= DisplayFeedbackString;
        LineSubmitter.OnSubmittedSuccessfully -= DisplayNewRandomLine;
    }

    public void DisplayNewRandomLine()
    {        
        var randomWords = _wordExtractor.GenerateRandomWords(wordCount);
        _randomString = string.Join(" ", randomWords.ToArray());

        if (_randomString.Length > _characterLimit)
        {
            _randomString = _randomString.Substring(0, _characterLimit).Trim();
            int index = _randomString.LastIndexOf(" ", StringComparison.Ordinal);
            _randomString = _randomString.Substring(0, index);
        }


        _targetTextDisplay.text = _randomString;

    }

    public void DisplayFeedbackString ()
    {
        _targetTextDisplay.text = StringJudge.CompareStringToTargetString(KeyboardInputString.InputString, _randomString);
    }

    private int CalculateCharacterLimit()
    {
        TextGenerator textGenerator = _targetTextDisplay.cachedTextGenerator;
        textGenerator.Populate(_targetTextDisplay.text, _targetTextDisplay.GetGenerationSettings(_targetTextDisplay.rectTransform.rect.size));

        int visibleChars = textGenerator.characterCountVisible;
        return visibleChars;
    }
}
