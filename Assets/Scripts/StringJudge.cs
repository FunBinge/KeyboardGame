using UnityEngine;
using System.Linq;


public class StringJudge
{        

    public static string CompareStringToTargetString(string inputStr, string targetString)
    {
        string [] judgedText = targetString.Select(c => c.ToString()).ToArray();

        for (var index = 0; index < inputStr.Length && index < targetString.Length; index++)
        {
            char targetLetter = targetString[index];
            char inputLetter = inputStr[index];

            if (inputLetter.Equals(targetLetter))
                judgedText[index] = MarkAsRight(targetLetter);            
            else            
                judgedText[index] = MarkAsWrong(targetLetter);
                        
        }

        string result = string.Join("", judgedText);

        return result; 
    }

    private static string MarkAsRight(char targetLetter)
    {
        return RichTextFormatter.StringColor(targetLetter == ' ' ? "*" : targetLetter.ToString(),
            RichTextFormatter.Colors.green);
    }
    private static string MarkAsWrong(char targetLetter)
    {
        return RichTextFormatter.StringColor(targetLetter == ' ' ? "*" : targetLetter.ToString(),
            RichTextFormatter.Colors.red);
    }

}