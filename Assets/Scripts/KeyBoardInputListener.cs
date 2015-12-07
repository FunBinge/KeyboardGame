using UnityEngine;
using System.Collections;

public class KeyBoardInputListener : MonoBehaviour {

    public delegate void KeyPressedAction(char keyEntered);
    public static event KeyPressedAction OnKeyInputReceived;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CurrentGameState == GameManager.GameState.IN_GAME && Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {

            if (OnKeyInputReceived != null && Input.inputString != "")
                OnKeyInputReceived.Invoke(Input.inputString[Input.inputString.Length - 1]);

        }
    }
}
