using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyboardInputString
{

    private static KeyboardInputString _instance;

    private KeyboardInputString(){ UpdateInputStringMaxLength(TargetTextString.TargetString.Length); }

    public static KeyboardInputString Instance
    {
        get { if (_instance == null)
                _instance = new KeyboardInputString();
                
                return _instance;
        }
    }

    private string _inputString = "";

    public delegate void InputStringEdited();
    public event InputStringEdited OnInputStringEdited;

    public string InputString {
        get { return _inputString; } 
        private set
        {
            _inputString = value;            
            if (OnInputStringEdited != null)
                OnInputStringEdited.Invoke();
        }
    }

    private int stringLengthLimit = 0;

    public void ReceiveInput(string inputKey)
    {       
        if (inputKey == "")
            return;

        if (_inputString.Length < stringLengthLimit)
            InputString += inputKey;        
    }

    public void DeleteLastChar()
    {
        if (_inputString.Length > 0)
            InputString = _inputString.Remove(_inputString.Length - 1);
    }

    public void ClearInputString()
    {
        _inputString = "";
    }

    public void UpdateInputStringMaxLength(int newMaxLength)
    {
        stringLengthLimit = newMaxLength;
    }
}


