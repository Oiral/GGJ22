using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DS;
using DS.ScriptableObjects;
using DS.Data;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public DSDialogueContainerSO container;

    DSDialogueSO currentDialogue;

    List<DSDialogueChoiceData> currentChoices;

    public TextMeshProUGUI dialogueName;

    UIManager uiManager;

    public bool testingString = false;

    public GameObject basicDialogueParent;
    public GameObject endDialogueParent;

    public TextMeshProUGUI endingDisplay;

    private void Awake()
    {
        uiManager = GetComponent<UIManager>();

        SetDialogue(container.UngroupedDialogues[0]);
    }


    public void SetDialogue(DSDialogueSO newDialogue)
    {
        if (testingString) return;


        currentDialogue = newDialogue;

        currentChoices = currentDialogue.Choices;

        if (newDialogue.name.Contains("Ending"))
        {
            DisplayEndDialogue();
        }

        //DebugCurrentDialogue();
        DisplayDialogue();
    }

    void DebugCurrentDialogue()
    {
        //Debug.Log(currentDialogue.name);

        Debug.Log(currentDialogue.Text);

        Debug.Log(currentDialogue.Choices.Count);

        if (currentDialogue.DialogueType == DS.Enumerations.DSDialogueType.MultipleChoice)
        {
            Debug.Log(currentChoices[0].Text);
        }
        else
        {
            Debug.Log("Non choice");
        }
        Debug.Log("-------------------------------------------------");
    }

    void DisplayDialogue()
    {
        dialogueName.text = currentDialogue.name;

        uiManager.NewString(currentDialogue.Text);
        GetComponent<ButtonManager>().CreateButtons(currentDialogue.Choices, currentDialogue.DialogueType == DS.Enumerations.DSDialogueType.MultipleChoice);
    }

    public void SelectChoice(int choice)
    {
        SetDialogue(currentChoices[choice].NextDialogue);
    }

    public void ResetDialogue()
    {
        endDialogueParent.SetActive(false);
        basicDialogueParent.SetActive(true);

        SetDialogue(container.UngroupedDialogues[0]);
    }

    public void DisplayEndDialogue()
    {
        endingDisplay.text = ToProperCase(currentDialogue.name.Replace("Ending", ""));

        endDialogueParent.SetActive(true);
        basicDialogueParent.SetActive(false);
    }

    string ToProperCase(string the_string)
    {
        // If there are 0 or 1 characters, just return the string.
        if (the_string == null) return the_string;
        if (the_string.Length < 2) return the_string.ToUpper();

        // Start with the first character.
        string result = the_string.Substring(0, 1).ToUpper();

        // Add the remaining characters.
        for (int i = 1; i < the_string.Length; i++)
        {
            if (char.IsUpper(the_string[i])) result += " ";
            result += the_string[i];
        }

        return result;
    }
}
