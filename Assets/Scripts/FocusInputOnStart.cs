using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FocusInputOnStart : MonoBehaviour {

	// Use this for initialization
	void OnGUI ()
	{   
        GetComponent<InputField>().ActivateInputField();
    }

}
