using UnityEngine;
using System.Collections;
using System.Linq;
using UnityEngine.UI;

public class StringJudge : MonoBehaviour
{
    
    private Text _inputText;
    private Text _targetText;

    private string _targetString;

	// Use this for initialization
	void Start ()
	{
	    _inputText = GameObject.FindGameObjectWithTag("InputString").GetComponent<Text>();
	    _targetText = GameObject.FindGameObjectWithTag("TargetString").GetComponent<Text>();
	    //_targetString = System.Text.RegularExpressions.Regex.Replace(_targetText.text, @"\s+", " ");	//Make sure target string is all single spaced
	    _targetString = _targetText.text;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.anyKeyDown)
	    {
	        _targetText.text = JudgeText(_inputText.text.ToCharArray(), _targetString.ToCharArray());
	    }
	}

    private string JudgeText(char[] inputStr, char[] targetStr)
    {
        var inputText = inputStr.Select(c => c.ToString()).ToArray();
        var targetText = targetStr.Select(c => c.ToString()).ToArray();

        var tempTargetText = (string[])targetText.Clone();

        for (int index = 0; index < inputText.Length; index++)
        {
            string targetLetter = tempTargetText[index];
            string inputLetter = inputText[index];

            if (inputLetter != targetLetter)
            {
                if (targetLetter != " ")
                    targetText[index] = "<color=red>" + targetLetter + "</color>";
                else
                {
                    targetText[index] = "<color=red>" + "*" + "</color>";
                }
            }
            else
            {
                if (targetLetter != " ")
                    targetText[index] = "<color=green>" + targetLetter + "</color>";
                else
                {
                    targetText[index] = "<color=green>" + "*" + "</color>";
                }
            }
        }

        return string.Join("", targetText);
    }
}
