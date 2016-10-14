using UnityEngine;
using System.Collections;

public class ClickDetection : MonoBehaviour {

    private Conversation conversation;
    private bool disableClicks;

    void Awake()
    {
        conversation = GetComponent<Conversation>();
        conversation.ConvoLocker += AllowClicks;
    }

    void AllowClicks(bool blockClicks)
    {
        Debug.Log("Disable Clicks");
        disableClicks = blockClicks;
    }


    //Detect if NPC is clicked
    void OnMouseDown()
    {
        if(disableClicks == false)
        {
            //tell conversation class a conversation was started
            conversation.ConversationStart();
        }
        else
        {
            Debug.Log("Youre already talking");
        }
        
    }
}
