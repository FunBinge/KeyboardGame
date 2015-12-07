using UnityEngine;
using UnityEngine.UI;

public class KeyboardInput : MonoBehaviour {

    public Text textString;

    private char _keyEntered;
    private char _currentLetter;
    private int _counter = 0;

        void Update ()
    {

        string textStream = textString.text;

        if (_counter != textStream.Length)
        {
            _currentLetter = textStream[_counter];
        }
        else
        {
            Debug.Log("You won");
        }

        foreach (char c in Input.inputString)
        {
            _keyEntered = c;
        }

        if (Input.anyKeyDown)
        {
            if (_keyEntered == _currentLetter)
            {
                textString.text = textString.text.Insert(_counter, "<color=green>");
                textString.text = textString.text.Insert(_counter + 14, "</color>");
                _counter += 14 + 8;
            }
            else
            {
                textString.text = textString.text.Insert(_counter, "<color=red>");
                textString.text = textString.text.Insert(_counter + 12, "</color>");
                _counter += 12 + 8;
            }
        }
    }
}
