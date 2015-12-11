using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class UIKeyboard : MonoBehaviour
{

    private List<UIKey> keys = new List<UIKey>();
    private UIKey _targetKey;
    private UIKey _lShiftKey;
    private UIKey _rShiftKey;


    void Awake()
    {
        foreach (Transform child in transform)
        {
            keys.Add(new UIKey(child.name, child.GetComponent<SpriteRenderer>()));
        }

        _targetKey = keys[0];
        _lShiftKey = FindKey("LeftShift");
        _rShiftKey = FindKey("RightShift");
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.IN_GAME)
            HighlightNextChar();
    }

    void HighlightNextChar()
    {
        if (!KeyboardInputString.Instance.ReachedMaxLength())
        {
            string keyId = TargetTextString.StringToMatch[KeyboardInputString.Instance.InputString.Length].ToString();

            if (keyId == " ")
                keyId = "Spacebar";

            if (_targetKey.Id != keyId)
            {
                UIKey keyToHighlight = FindKey(keyId);
                if (keyToHighlight != null)
                {
                    //Reset key color
                    _lShiftKey.HighlightKey(Color.white);
                    _rShiftKey.HighlightKey(Color.white);
                    _targetKey.HighlightKey(Color.white);

                    keyToHighlight.HighlightKey(Color.yellow);
                    _targetKey = keyToHighlight;
                    if (keyId.Length < 1 && char.IsUpper(keyId, 0))
                    {
                        _lShiftKey.HighlightKey(Color.yellow);
                        _rShiftKey.HighlightKey(Color.yellow);
                    }
                }
            }
        }
    }

    private IEnumerator HighlightKeyForSeconds(float seconds, UIKey key)
    {
        key.HighlightKey(Color.blue);

        yield return new WaitForSeconds(seconds);
        key.HighlightKey(Color.white);
    }

    UIKey FindKey(string keyId)
    {
        return keys.Find(key => key.Id.ToLower().Equals(keyId.ToLower()));
    }

}

internal class UIKey
{
    private SpriteRenderer _sprite;
    private string _id;

    public UIKey(string id, SpriteRenderer spRenderer)
    {
        _id = id;
        _sprite = spRenderer;
    }

    public void HighlightKey(Color tint)
    {
        _sprite.color = tint;
     
    }

    public string Id {
        get { return _id; }
    }
}
