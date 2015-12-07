using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour {

    public delegate void KeyPressedAction(char keyEntered);
    public static event KeyPressedAction OnKeyboardInputReceived;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CurrentGameState == GameManager.GameState.IN_GAME && Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {
            if (OnKeyboardInputReceived != null)
                OnKeyboardInputReceived.Invoke(Input.inputString[Input.inputString.Length]);
        }
    }
}
