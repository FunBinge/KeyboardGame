using System;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class UIKeyboard : MonoBehaviour
{

    private List<UIKey> _stringKeys;
    private List<UIKey> _modifierKeys; 
    private UIKey _targetKey;


    void Awake()
    {
        LoadKeyboardKeyLists();

        _targetKey = _stringKeys[0];
    }

    void Update()
    {
        if (GameManager.Instance.CurrentGameState == GameManager.GameState.IN_GAME)
            HighlightNextChar();
    }

    private void LoadKeyboardKeyLists()
    {
        GameObject[] keyObjects = GameObject.FindGameObjectsWithTag("KeyboardKey");
        _stringKeys =
            new List<UIKey>(
                keyObjects.Select(key => key.GetComponent<UIKey>()).Where(key => key.keyType == UIKey.KeyType.String));
        _modifierKeys =
            new List<UIKey>(
                keyObjects.Select(key => key.GetComponent<UIKey>()).Where(key => key.keyType == UIKey.KeyType.Modifier));
    }    

    void HighlightNextChar()
    {
        if (!KeyboardInputString.Instance.ReachedMaxLength())
        {
            string keyId = TargetTextString.StringToMatch[KeyboardInputString.Instance.InputString.Length].ToString();

            if (keyId == " ")
                keyId = "Spacebar";

            if (!_targetKey.MatchesValue(keyId))
            {
                UIKey keyToHighlight = FindKey(_stringKeys, keyId);

                if (keyToHighlight != null)
                {        
                    ResetHighlights();

                    //Highlight shift if necessary
                    if (keyToHighlight.upperCaseValue.Equals(keyId))
                        FindKey(_modifierKeys, keyToHighlight.shiftToUse.ToString()).HighlightKey(Color.yellow);

                    //Highlight new TargetKey
                    keyToHighlight.HighlightKey(Color.yellow);
                    _targetKey = keyToHighlight;
                }
            }
        }
        else
        {
            ResetHighlights();
            FindKey(_modifierKeys, "Enter").HighlightKey(Color.yellow);
        }
    }

    private void ResetHighlights()
    {
        _targetKey.HighlightKey(Color.white);
        _modifierKeys.ForEach(key => key.HighlightKey(Color.white));
    }

    private IEnumerator HighlightKeyForSeconds(float seconds, UIKey key)
    {
        key.HighlightKey(Color.blue);

        yield return new WaitForSeconds(seconds);
        key.HighlightKey(Color.white);
    }

    UIKey FindKey(List<UIKey> listToSearch  ,string keyId)
    {
        return listToSearch.Find(key => key.MatchesValue(keyId));
    }

}