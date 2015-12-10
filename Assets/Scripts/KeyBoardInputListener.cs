using UnityEngine;

public class KeyBoardInputListener : MonoBehaviour {

    public delegate void SubmittedSuccessfully();
    public static event SubmittedSuccessfully OnSubmittedSuccessfully;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CurrentGameState == GameManager.GameState.IN_GAME && Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {
            foreach (char c in Input.inputString)
            {
                if (c == "\b"[0])
                {
                    KeyboardInputString.Instance.DeleteLastChar();
                    return;
                }

                if ((c == "\n"[0] || c == "\r"[0]) &&
                    TargetTextString.TargetString.Length == KeyboardInputString.Instance.InputString.Length)
                {
                                        
                    if (OnSubmittedSuccessfully != null)
                        OnSubmittedSuccessfully.Invoke();

                    Debug.Log("Clearing old string");
                    KeyboardInputString.Instance.ClearInputString();


                    return;
                }
                    
            }
            KeyboardInputString.Instance.ReceiveInput(Input.inputString);

        }
    }
}


