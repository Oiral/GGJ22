using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public GameObject basicDailogue;
    public GameObject rebootDialogue;
    public GameObject endScreenDialogue;
    public GameObject questionDialogue;
    public GameObject creditDialogue;
    public GameObject playfull1Dialogue;
    public GameObject playfull2Dialogue;

    public void SetObject(GameObject dialogueToTurnOn)
    {
        basicDailogue.SetActive(dialogueToTurnOn == basicDailogue);
        rebootDialogue.SetActive(dialogueToTurnOn == rebootDialogue);
        endScreenDialogue.SetActive(dialogueToTurnOn == endScreenDialogue);
        questionDialogue.SetActive(dialogueToTurnOn == questionDialogue);
        creditDialogue.SetActive(dialogueToTurnOn == creditDialogue);
        playfull1Dialogue.SetActive(dialogueToTurnOn == playfull1Dialogue);
        playfull2Dialogue.SetActive(dialogueToTurnOn == playfull2Dialogue);
    }
}
