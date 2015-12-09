using UnityEngine;

public class LineSubmitter : MonoBehaviour
{
    public delegate void SubmittedSuccessfully();
    public static event SubmittedSuccessfully OnSubmittedSuccessfully;

    private RandomTargetString _targetText;

    void Start()
    {
        _targetText = GameObject.FindGameObjectWithTag("TargetString").GetComponent<RandomTargetString>();       

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            AttemptToSubmitLine(KeyboardInputString.InputString);
        }
    }

    public void AttemptToSubmitLine(string submittedStr)
    {
        if (submittedStr.Length <= 0)
            return;
        if (_targetText.TargetStringLength == KeyboardInputString.InputString.Length && OnSubmittedSuccessfully != null)
            OnSubmittedSuccessfully.Invoke();
    }
}