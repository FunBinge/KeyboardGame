using UnityEngine;

public class LineSubmitter : MonoBehaviour
{
    public delegate void SubmittedSuccessfully();
    public static event SubmittedSuccessfully OnSubmittedSuccessfully;
    
    private MonitorText _monitor;

    void Start()
    {        
        _monitor = GameObject.FindGameObjectWithTag("Monitor").GetComponentInChildren<MonitorText>();

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

        if (TargetTextString.TargetString.Length == KeyboardInputString.InputString.Length && OnSubmittedSuccessfully != null)
        {            
            _monitor.SubmitStringToMonitor(KeyboardInputString.InputString);
            OnSubmittedSuccessfully.Invoke();
        }
    }
}