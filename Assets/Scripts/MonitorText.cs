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

    public void SubmitStringToMonitor(string str)
    {
        _text.text += "\n>" + str;
    }
}
