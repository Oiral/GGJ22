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

    public TextMeshProUGUI endingDisplay;

    public ScreenManager screenManager;

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
        else if (newDialogue.name.Contains("Reboot"))
        {
            DisplayRebootDialogue();
        }
        else if (newDialogue.name == "Playful1")
        {
            DisplayPlayfull1Dialogue();
        }
        else if (newDialogue.name == "Playful2")
        {
            DisplayPlayfull2Dialogue();
        }
        else if (newDialogue.name.Contains("Question"))
        {
            DisplayQuestionDialogue();
        }
        else if (newDialogue.name.Contains("Credits"))
        {
            DisplayCreditDialogue();
        }
        else
        {
            screenManager.SetObject(screenManager.basicDailogue);
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

    

    public void SelectChoice(int choice)
    {
        SetDialogue(currentChoices[choice].NextDialogue);
    }

    public void ResetDialogue()
    {
        screenManager.SetObject(screenManager.basicDailogue);

        SetDialogue(container.UngroupedDialogues[0]);
    }

    #region Dialogue options
    void DisplayDialogue()
    {
        dialogueName.text = currentDialogue.name;

        uiManager.NewString(currentDialogue.Text);
        GetComponent<ButtonManager>().CreateButtons(currentDialogue.Choices, currentDialogue.DialogueType == DS.Enumerations.DSDialogueType.MultipleChoice);
    }

    public void DisplayEndDialogue()
    {
        endingDisplay.text = ToProperCase(currentDialogue.name.Replace("Ending", ""));

        screenManager.SetObject(screenManager.endScreenDialogue);
    }

    public void DisplayRebootDialogue()
    {
        //TODO
        endingDisplay.text = ToProperCase(currentDialogue.name);

        screenManager.SetObject(screenManager.rebootDialogue);
    }
    public void DisplayPlayfull1Dialogue()
    {
        //TODO

        screenManager.SetObject(screenManager.playfull1Dialogue);
    }
    public void DisplayPlayfull2Dialogue()
    {
        //TODO

        screenManager.SetObject(screenManager.playfull2Dialogue);
    }
    public void DisplayQuestionDialogue()
    {
        //TODO
        endingDisplay.text = ToProperCase(currentDialogue.name.Replace("Ending", ""));

        screenManager.SetObject(screenManager.questionDialogue);
    }

    public void DisplayCreditDialogue()
    {
        //TODO
        endingDisplay.text = ToProperCase(currentDialogue.name.Replace("Ending", ""));

        screenManager.SetObject(screenManager.creditDialogue);
    }
    #endregion

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
