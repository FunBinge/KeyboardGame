using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class StringJudge : MonoBehaviour
{        
    private Text _targetDisplayText;
    private string _targetString;

    // Use this for initialization
	void Start ()
	{	    
	    _targetDisplayText = GameObject.FindGameObjectWithTag("TargetString").GetComponent<Text>();	    
	    _targetString = _targetDisplayText.text;
	}

    void OnEnable()
    {
        KeyboardInputString.OnInputStringEdited += JudgeText;
    }

    void OnDisable()
    {
        KeyboardInputString.OnInputStringEdited -= JudgeText;
    }

    public void UpdateTargetString()
    {
        _targetString = _targetDisplayText.text;
    }

    public void JudgeText(string inputStr)
    {
        string [] judgedText = _targetString.Select(c => c.ToString()).ToArray();

        for (var index = 0; index < inputStr.Length && index < _targetString.Length; index++)
        {
            char targetLetter = _targetString[index];
            char inputLetter = inputStr[index];

            if (inputLetter.Equals(targetLetter))
                judgedText[index] = MarkAsRight(targetLetter);            
            else            
                judgedText[index] = MarkAsWrong(targetLetter);
                        
        }
        _targetDisplayText.text = string.Join("", judgedText);
    }

    private string MarkAsRight(char targetLetter)
    {
        return RichTextFormatter.StringColor(targetLetter == ' ' ? "*" : targetLetter.ToString(),
            RichTextFormatter.Colors.green);
    }
    private string MarkAsWrong(char targetLetter)
    {
        return RichTextFormatter.StringColor(targetLetter == ' ' ? "*" : targetLetter.ToString(),
            RichTextFormatter.Colors.red);
    }

}