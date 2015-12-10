using UnityEngine;
using UnityEngine.UI;

public class MonitorText : MonoBehaviour
{

    private Text _text;

    void Start()
    {
        _text = GetComponent<Text>();
    }

    void OnEnable()
    {
        KeyBoardInputListener.OnSubmittedSuccessfully += SubmitStringToMonitor;
    }

    void OnDisable()
    {
        KeyBoardInputListener.OnSubmittedSuccessfully -= SubmitStringToMonitor;

    }

    public void SubmitStringToMonitor()
    {
        Debug.Log("Submitting results to monitor");
        _text.text += "\n>" + StringJudge.CompareStringToTargetString(TargetTextString.TargetString, KeyboardInputString.Instance.InputString);
    }
}
