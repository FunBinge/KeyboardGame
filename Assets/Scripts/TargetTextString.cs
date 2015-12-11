using System;
using UnityEngine;
using UnityEngine.UI;

//Hey Tegan, I'll be going on a 20 day holiday soon. I'd like to see you before leaving, 
//lets grab a boost/coffee/pear cider with cinamon this Monday. 
//If you behave I might even let you throw the first pretzel when we go pretzel throwing, it's going to be a blast. 

public class TargetTextString : MonoBehaviour
{
    
    public int wordCount = 5;    

    private WordExtractor _wordExtractor;
    private Text _targetTextDisplay;
    private int _characterLimit = 0;
    private static string _stringToMatch;

    public static string StringToMatch {
        get { return _stringToMatch; }
    }

    // Use this for initialization
    void Awake ()
	{        
        _wordExtractor = new WordExtractor(Resources.Load<TextAsset>("Words"));
	    _targetTextDisplay = GetComponent<Text>();
        _characterLimit = CalculateCharacterLimit();              
        DisplayNewRandomLine();

        KeyboardInputString.Instance.OnInputStringEdited += DisplayFeedbackString;
        KeyBoardInputListener.OnSubmit += OnSubmit;
    }   

    void OnDisable()
    {
        KeyboardInputString.Instance.OnInputStringEdited -= DisplayFeedbackString;
        KeyBoardInputListener.OnSubmit -= OnSubmit;
    }

    private void OnSubmit(string submittedString)
    {
        DisplayNewRandomLine();
    }

    public void DisplayNewRandomLine()
    {
        _stringToMatch = _wordExtractor.GenerateRandomString(wordCount, _characterLimit);

        _targetTextDisplay.text = _stringToMatch;  
        KeyboardInputString.Instance.UpdateInputStringMaxLength(_stringToMatch.Length);      

    }

    public void DisplayFeedbackString ()
    {
        _targetTextDisplay.text = StringJudge.CompareStringToTargetString(KeyboardInputString.Instance.InputString, _stringToMatch);
    }

    private int CalculateCharacterLimit()
    {
        TextGenerator textGenerator = _targetTextDisplay.cachedTextGenerator;
        textGenerator.Populate(_targetTextDisplay.text, _targetTextDisplay.GetGenerationSettings(_targetTextDisplay.rectTransform.rect.size));

        int visibleChars = textGenerator.characterCountVisible;
        return visibleChars;
    }
}
