using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Xml.Serialization;

public class UIKeyboard : MonoBehaviour
{

    private List<UIKey> keys = new List<UIKey>();

    void OnEnable()
    {
        KeyBoardInputListener.OnKeyInputReceived += HighlightKeyEntered;
    }

    void OnDisable()
    {
        KeyBoardInputListener.OnKeyInputReceived -= HighlightKeyEntered;
    }

    void Awake()
    {
        foreach (Transform child in transform)
        {
            keys.Add(new UIKey(child.name[0], child.GetComponent<SpriteRenderer>()));
        }
    }

    void HighlightKeyEntered(char keyId)
    {
        StartCoroutine(HighlightKeyForSeconds(.05f, keyId));
    }

    public IEnumerator HighlightKeyForSeconds(float seconds, char keyId)
    {
        UIKey key = FindKey(keyId);
        key.HighlightKey(Color.blue);
        yield return new WaitForSeconds(seconds);
        key.HighlightKey(Color.white);
    }

    UIKey FindKey(char keyId)
    {
        return keys.Find(key => key.Id.Equals(keyId));
    }







    //public Text textString;

    //private char _keyEntered;
    //private char _currentLetter;
    //private int _counter = 0;

    //void Update ()
    //{

    //    string textStream = textString.text;

    //    if (_counter != textStream.Length)
    //    {
    //        _currentLetter = textStream[_counter];
    //    }
    //    else
    //    {
    //        Debug.Log("You won");
    //    }

    //    foreach (char c in Input.inputString)
    //    {
    //        _keyEntered = c;
    //    }

    //    if (Input.anyKeyDown)
    //    {
    //        if (_keyEntered == _currentLetter)
    //        {
    //            textString.text = textString.text.Insert(_counter, "<color=green>");
    //            textString.text = textString.text.Insert(_counter + 14, "</color>");
    //            _counter += 14 + 8;
    //        }
    //        else
    //        {
    //            textString.text = textString.text.Insert(_counter, "<color=red>");
    //            textString.text = textString.text.Insert(_counter + 12, "</color>");
    //            _counter += 12 + 8;
    //        }
    //    }
    //}
}

internal class UIKey
{
    private SpriteRenderer _sprite;
    private char _id;

    public UIKey(char id, SpriteRenderer spRenderer)
    {
        _id = id;
        _sprite = spRenderer;
    }

    public void HighlightKey(Color tint)
    {
        _sprite.color = tint;
     
    }

    public char Id {
        get { return _id; }
    }
}
