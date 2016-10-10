using UnityEngine;
using System.Collections;

public class ClickDetection : MonoBehaviour {

    private Conversation conversation;

    void Awake()
    {
        conversation = GetComponent<Conversation>();
    }


    //Detect if NPC is clicked
    void OnMouseDown()
    {
        //tell conversation class a conversation was started
        conversation.ConversationStart();
    }
}
