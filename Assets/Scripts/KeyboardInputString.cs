﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class KeyboardInputString : MonoBehaviour
{
    public delegate void InputStringEdited(string newStr);
    public static event InputStringEdited OnInputStringEdited;

    private Text _targetText;
    private int stringLengthLimit = 0;

    private static string _inputString = "";
    public static string InputString {
        get { return _inputString; } 
        private set
        {
            _inputString = value;    
                 
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
        LineSubmitter.OnSubmittedSuccessfully += OnSubmit;
    }

    void OnDisable()
    {
        KeyBoardInputListener.OnKeyInputReceived -= ReceiveInput;
        LineSubmitter.OnSubmittedSuccessfully -= OnSubmit;
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
        if (_inputString.Length > 0)
            InputString = _inputString.Remove(_inputString.Length - 1);
    }

    private void ClearInputString()
    {
        _inputString = "";
    }

    private void UpdateInputFieldWordLimit()
    {
        stringLengthLimit = _targetText.text.Length;
    }

    public void OnSubmit()
    {        
        ClearInputString();
        UpdateInputFieldWordLimit();
    }
}

