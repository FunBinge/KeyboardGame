using UnityEngine;

public class KeyBoardInputListener : MonoBehaviour {

    public delegate void Submit(string str);
    public static event Submit OnSubmit;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.IN_GAME && Input.anyKeyDown && !Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1))
        {
            var key = Input.inputString;

            foreach (char c in key)
            {
                if (IsBackspace(c))
                {
                    KeyboardInputString.Instance.DeleteLastChar();
                    return;
                }

                if (IsEnter(c) && KeyboardInputString.Instance.ReachedMaxLength())
                {
                    if (OnSubmit != null)
                        OnSubmit.Invoke(StringJudge.CompareStringToTargetString(TargetTextString.StringToMatch, KeyboardInputString.Instance.InputString));

                    KeyboardInputString.Instance.ClearInputString();
                    KeyboardInputString.Instance.UpdateInputStringMaxLength(TargetTextString.StringToMatch.Length);

                    return;
                }
            }

            if (key != "")
                KeyboardInputString.Instance.ReceiveInput(key);

        }
    }

    private bool IsEnter(char c)
    {
        return (c == "\n"[0] || c == "\r"[0]);
    }

    private bool IsBackspace(char c)
    {
        return (c == "\b"[0]);
    }
}


