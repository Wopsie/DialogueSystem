using UnityEngine;
using System.Collections;

//this class represents a choice that the player can make in the conversation
public class Choice  {

    public void AddChoice()
    {
        //create a choice depending on received

        //create button (must be done in an update somewhere
        if (GUI.Button(new Rect(10, 10, 100, 90), "player option"))
        {
            Debug.Log("Chose an option");
        }
    }

    public void DeleteChoice()
    {
        //delete a choice (when the choice is no longer relevant)
    }

    //with monobehavior this will act like an update
    void OnGUI()
    {
        
        
        
    }

}
