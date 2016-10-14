using UnityEngine;
using System.Collections;

public class MouseClick : MonoBehaviour {

    private bool disableClicks = false;
    private Conversation conversation;

	void Update()
    {
        if(Input.GetMouseButtonDown(0) && disableClicks == false)
        {
            
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    Debug.Log(hit.collider.gameObject.name);

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

    void AllowClicks(bool blockClicks)
    {
        disableClicks = blockClicks;

        if(blockClicks == false)
        {
            conversation.ConvoLocker -= AllowClicks;
        }
    }

}
