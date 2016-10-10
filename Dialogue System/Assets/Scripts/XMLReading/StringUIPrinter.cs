using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StringUIPrinter : MonoBehaviour {

    [SerializeField]
    private Text uiText;

    public void PrintToUI(string text)
    {
        uiText.text = text;
    }
}
