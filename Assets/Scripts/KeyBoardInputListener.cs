using System;
using UnityEngine;
using System.Collections;

public class KeyBoardInputListener : MonoBehaviour {

    public delegate void KeyPressedAction(string keyEntered);
    public static event KeyPressedAction OnKeyInputReceived;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CurrentGameState == GameManager.GameState.IN_GAME && Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {

            if (OnKeyInputReceived != null)
            {

                string keyId = Input.inputString;

                if (keyId == " ")
                    keyId = "Spacebar";
                if (Input.GetKeyDown(KeyCode.LeftShift))
                    keyId = "LeftShift";
                if (Input.GetKeyDown(KeyCode.RightShift))
                    keyId = "RightShift";
                if (Input.GetKeyDown(KeyCode.Return))
                    keyId = "Enter";
                if (Input.GetKeyDown(KeyCode.CapsLock))
                    keyId = "Caps";
                if (Input.GetKeyDown(KeyCode.Backspace))
                    keyId = "BackSpace";

                if (keyId != "")
                    OnKeyInputReceived.Invoke(keyId);
            }

        }
    }
}
