using UnityEngine;
using UnityEngine.Events;

public class LineSubmitter : MonoBehaviour
{
    public SubmitLineEvent OnSubmittedSuccessfully;

    private RandomTargetString _targetText;
    private KeyboardInputString _keyboardInputString;

    void Start()
    {
        _targetText = GameObject.FindGameObjectWithTag("TargetString").GetComponent<RandomTargetString>();
        _keyboardInputString = GameObject.FindGameObjectWithTag("InputString").GetComponent<KeyboardInputString>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AttemptToSubmitLine(_keyboardInputString.InputString);
        }
    }

    public void AttemptToSubmitLine(string submittedStr)
    {
        if (submittedStr.Length <= 0)
            return;
        if (_targetText.TargetTextLength == _keyboardInputString.InputString.Length && OnSubmittedSuccessfully != null)
            OnSubmittedSuccessfully.Invoke(submittedStr);
    }
}

[System.Serializable]
public class SubmitLineEvent : UnityEvent<string>
{

}
