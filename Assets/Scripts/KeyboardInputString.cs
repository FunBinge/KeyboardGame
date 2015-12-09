using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyboardInputString : MonoBehaviour
{
    public delegate void InputStringEdited(string newStr);
    public static event InputStringEdited OnInputStringEdited;

    private Text _targetText;
    private int stringLengthLimit = 0;

    private string _inputString = "";
    public string InputString {
        get { return _inputString; } 
        private set
        {
            _inputString = value;
            Debug.Log(_inputString);
            if (OnInputStringEdited != null)
                OnInputStringEdited.Invoke(_inputString);
        }
    }

    void Start()
    {
        GetComponent<InputField>();
        _targetText = GameObject.FindGameObjectWithTag("TargetString").GetComponent<Text>();
        UpdateInputFieldWordLimit();
    }

    void OnEnable()
    {
        KeyBoardInputListener.OnKeyInputReceived += ReceiveInput;
    }

    void OnDisable()
    {
        KeyBoardInputListener.OnKeyInputReceived -= ReceiveInput;
    }

    private void ReceiveInput(string inputKey)
    {
        if (inputKey.Equals("BackSpace"))
        {
            DeleteLastChar();
            return;
        }

        if (_inputString.Length < stringLengthLimit)
            InputString += inputKey;
        
    }

    private void DeleteLastChar()
    {
        InputString = _inputString.Remove(_inputString.Length - 1);
    }

    private void ClearInputString()
    {
        InputString = "";
    }

    private void UpdateInputFieldWordLimit()
    {
        stringLengthLimit = _targetText.text.Length;
    }

    //Event called by keyboard "LineSubmitter"
    public void OnSubmit()
    {
        ClearInputString();
        UpdateInputFieldWordLimit();
    }
}


