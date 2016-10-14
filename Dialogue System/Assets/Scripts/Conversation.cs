﻿using UnityEngine;
using System.Collections;


/*
 * MAKE POSSIBLE TO END CONVERSATION
 */


public class Conversation : MonoBehaviour
{
    XmlReader reader = new XmlReader();

    private StringUIPrinter namePrinter;
    private StringUIPrinter dialogeuePrinter;
    
    private ChoiceButtonHandler choiceButtons;

    public delegate void LockConvo(bool talks);
    public LockConvo ConvoLocker;

    private bool isTalking;

    [SerializeField]
    private string file;    //xml file name
    [SerializeField]
    private string path;    //path through xml file
    [SerializeField]
    private int id;         //number that represents the relevant character script in the xml file character array
    [SerializeField]
    private string initialXmlTag;   //the part of the xml that is first shown to the player upon starting a conversation

    private string text;

    void Awake()
    {
        choiceButtons = GameObject.FindWithTag("Canvas").GetComponent<ChoiceButtonHandler>();
        namePrinter = GameObject.FindWithTag("NameText").GetComponent<StringUIPrinter>();
        dialogeuePrinter = GameObject.FindWithTag("DialogueText").GetComponent<StringUIPrinter>();
    }

    public void ConversationStart()
    {
        Debug.Log("Start Talking " + gameObject.name);

        isTalking = true;
        //send out delegate to disable certain features like movement etc.
        if (ConvoLocker != null)
        {
            ConvoLocker(isTalking);
        }


        text = reader.ReadXml(file, path, "Name" , id);
        namePrinter.PrintToUI(text);
        text = reader.ReadXml(file, path, initialXmlTag, id);
        dialogeuePrinter.PrintToUI(text);

        //present UI button choices loaded from xml.    These buttons call the ConversationUpdate method and add a parameter
        GetChoices("/" + initialXmlTag);
    }

    //read the <Response> tags from the xml file within the current node and print them to seperate buttons
    void GetChoices(string location)
    {
        //send array of strings to script to print the contents to GUI buttons
        
        choiceButtons.GetChoices(reader.ReadSubnodes(file, path + location, id), reader.ChoiceAttributes);
        choiceButtons.PassChoice += ConversationUpdate;
    }

    //call this when changes are made to the conversation
    void ConversationUpdate(string lineTree)
    {
        choiceButtons.PassChoice -= ConversationUpdate;
        //Debug.Log("NPC Response: " + reader.ReadXml(file, path, lineTree, id));

        

        //if attribute is bigger than number of avalible linetree, end conversation

        Debug.Log(lineTree);

        if (lineTree == "Tree200")
        {
            Debug.Log("Gotta stop talking");
            EndConversation();
        }
        else
        {

            text = reader.ReadXml(file, path, lineTree, id);
            dialogeuePrinter.PrintToUI(text);

            Debug.Log("Gotta get choices");
            GetChoices("/" + lineTree);
        }
        
    }

    //call this when the player ends the conversation with the NPC
    void EndConversation()
    {
        //Debug.Log("Gotta end conversation");
        namePrinter.PrintToUI(" ");
        dialogeuePrinter.PrintToUI(" ");

        isTalking = false;

        if(ConvoLocker != null)
        {
            ConvoLocker(isTalking);
        }
    }
}
