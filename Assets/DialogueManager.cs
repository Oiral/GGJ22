using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DS;
using DS.ScriptableObjects;
using DS.Data;

public class DialogueManager : MonoBehaviour
{
    public DSDialogueContainerSO container;

    DSDialogueSO currentDialogue;

    public List<DSDialogueChoiceData> currentChoices;

    private void Awake()
    {
        SetDialogue(container.UngroupedDialogues[0]);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (currentDialogue.DialogueType == DS.Enumerations.DSDialogueType.SingleChoice)
            {
                SetDialogue(currentDialogue.Choices[0].NextDialogue);
            }
        }
    }


    public void SetDialogue(DSDialogueSO newDialogue)
    {
        currentDialogue = newDialogue;
        currentChoices = currentDialogue.Choices;
        DebugCurrentDialogue();
    }

    public void DebugCurrentDialogue()
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
}
