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
        KeyBoardInputListener.OnKeyInputReceived += keyId => HighlightKeyEntered(keyId);
    }

    void OnDisable()
    {
        KeyBoardInputListener.OnKeyInputReceived -= keyId => HighlightKeyEntered(keyId);
    }

    void Awake()
    {
        foreach (Transform child in transform)
        {
            keys.Add(new UIKey(child.name, child.GetComponent<SpriteRenderer>()));
        }
    }

    void HighlightKeyEntered(string keyId)
    {
        StartCoroutine(HighlightKeyForSeconds(.05f, keyId));
    }

    public IEnumerator HighlightKeyForSeconds(float seconds, string keyId)
    {
        UIKey key = FindKey(keyId);
        if (key == null) yield break;

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
