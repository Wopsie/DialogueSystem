using UnityEngine;
using System.Collections;

//this class represents a choice that the player can make in the conversation
public class Choice {

    public void AddChoices(string[] choices)
    {
        //create a choice depending on received
        Debug.Log(choices);

        foreach(string s in choices)
        {
            //tell gui script to make a button with the text on it
            Debug.Log("a string was found");
        }
    }

    public void DeleteChoice()
    {
        //delete a choice (when the choice is no longer relevant)
    }
}
