using UnityEngine;
using UnityEngine.UI;

public class MonitorText : MonoBehaviour
{

    private Text _text;

	// Use this for initialization
	void Start ()
	{
	    _text = GetComponent<Text>();
	}

    void OnEnable()
    {
        //LineSubmitter.OnSubmittedSuccessfully += SubmitStringToMonitor;
    }

    void OnDisable()
    {
        //LineSubmitter.OnSubmittedSuccessfully -= SubmitStringToMonitor;
    }

    public void SubmitStringToMonitor(string str)
    {
        _text.text += "\n>" + str;
    }
}
