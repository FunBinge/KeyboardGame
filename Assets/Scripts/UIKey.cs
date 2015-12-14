using UnityEngine;
using UnityEngine.UI;

class UIKey:MonoBehaviour
{
    public string lowerCaseValue;
    public string upperCaseValue;
    public ShiftPosition shiftToUse;
    public KeyType keyType;

    public enum ShiftPosition
    {
        RightShift, LeftShift
    }

    public enum KeyType
    {
        String, Modifier
    }

    private Image _image;

    void Start()
    {
        gameObject.tag = "KeyboardKey";
        _image = GetComponent<Image>();
    }

    public void HighlightKey(Color tint)
    {
        _image.color = tint;
     
    }

    public bool MatchesValue(string value)
    {
        return (value.Equals(lowerCaseValue) || value.Equals(upperCaseValue));
    }

}