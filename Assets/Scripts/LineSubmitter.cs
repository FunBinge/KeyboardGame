using UnityEngine;

public class LineSubmitter : MonoBehaviour
{   
    private MonitorText _monitor;

    void Start()
    {        
        _monitor = GameObject.FindGameObjectWithTag("Monitor").GetComponentInChildren<MonitorText>();

    }


    public void AttemptToSubmitLine(string submittedStr)
    {
        if (submittedStr.Length <= 0)
            return;
    }
}