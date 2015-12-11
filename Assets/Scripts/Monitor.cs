using UnityEngine;
using UnityEngine.UI;

public class Monitor : MonoBehaviour
{
    private Text _monitorText;

    void Start()
    {
        _monitorText = GetComponentInChildren<Text>();
    }

    void OnEnable()
    {
        KeyBoardInputListener.OnSubmit += SubmitStringToMonitor;
    }

    void OnDisable()
    {
        KeyBoardInputListener.OnSubmit -= SubmitStringToMonitor;

    }

    public void SubmitStringToMonitor(string str)
    {
        _monitorText.text += "\n>" + str;
    }
}
