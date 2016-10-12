using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetButtonElements : MonoBehaviour {

    private Text buttonText;

    public void GetElements()
    {
        buttonText = gameObject.GetComponentInChildren<Text>();
        buttonText.text = "Hey";
    }
	
}
