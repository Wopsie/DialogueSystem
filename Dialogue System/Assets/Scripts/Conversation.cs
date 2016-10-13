using UnityEngine;
using System.Collections;

public class Conversation : MonoBehaviour
{
    XmlReader reader = new XmlReader();

    private StringUIPrinter namePrinter;
    private StringUIPrinter dialogeuePrinter;

    
    private ChoiceButtonHandler choiceButtons;

    [SerializeField]
    private string file;    //xml file name
    [SerializeField]
    private string path;    //path through xml file
    [SerializeField]
    private int id;         //number that represents the relevant character script in the xml file character array

    private string text;

    private Choice choice = new Choice();
    

    void Awake()
    {
        choiceButtons = GameObject.FindWithTag("Canvas").GetComponent<ChoiceButtonHandler>();
        namePrinter = GameObject.FindWithTag("NameText").GetComponent<StringUIPrinter>();
        dialogeuePrinter = GameObject.FindWithTag("DialogueText").GetComponent<StringUIPrinter>();
    }

    public void ConversationStart()
    {
        //send out delegate to disable certain features like movement etc.

        text = reader.ReadXml(file, path, "Name" , id);
        namePrinter.PrintToUI(text);
        text = reader.ReadXml(file, path, "Greeting", id);
        dialogeuePrinter.PrintToUI(text);

        //present UI button choices loaded from xml.    These buttons call the ConversationUpdate method and add a parameter
        GetChoices();

    }

    //read the <Response> tags from the xml file within the current node and print them to seperate buttons
    void GetChoices()
    {
        //send array of strings to script to print the contents to GUI buttons
        //choice.AddChoices(reader.ReadSubnodes(file, path + "/Greeting", id));
        choiceButtons.GetChoices(reader.ReadSubnodes(file, path + "/Greeting", "Response", id));

        choiceButtons.PassChoice += ConversationUpdate;
    }

    //call this when changes are made to the conversation
    void ConversationUpdate(int index)
    {
        choiceButtons.PassChoice -= ConversationUpdate;
        Debug.Log("NPC Response: " + reader.ReadXml(file, path, "Greeting", id));

        
    }

    //call this when the player ends the conversation with the NPC
    void EndConversation()
    {

    }

}
