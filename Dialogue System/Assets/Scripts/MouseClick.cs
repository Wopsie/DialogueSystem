using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

    private bool disableClicks = false;
    private Conversation conversation;

	void Update()
    {
        //if clicked & clicks are not disabled (not talking with NPC)
        if(Input.GetMouseButtonDown(0) && disableClicks == false)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //fire raycast to see what the mouse clicked on
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    //not dependant on tags
                    if(hit.collider.gameObject.GetComponent<Conversation>() != null)
                    {
                        conversation = hit.collider.gameObject.GetComponent<Conversation>();
                        conversation.ConvoLocker += AllowClicks;

                        disableClicks = true;

                        conversation.ConversationStart();
                    } 
                }     
            }
        }
    }

    //toggle the ability to click on NPC's to start a conversation
    void AllowClicks(bool blockClicks)
    {
        disableClicks = blockClicks;

        if(blockClicks == false)
        {
            conversation.ConvoLocker -= AllowClicks;
        }
    }

}
