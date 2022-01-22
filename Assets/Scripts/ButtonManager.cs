using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DS.Data;
using TMPro;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    List<GameObject> createdButtons = new List<GameObject>();

    public GameObject buttonPrefab;
    public Transform buttonParent;
    public string singleChoice = "Continue";

    public AudioManager audioManager;

    public void CreateButtons(List<DSDialogueChoiceData> choices, bool multiChoice)
    {
        RemoveButtons();

        if (multiChoice)
        {

            for (int i = 0; i < choices.Count; i++)
            {
                CreateButton(choices[i].Text, i);
            }
        }
        else
        {
            CreateButton(singleChoice, 0);
        }
    }

    public void CreateButton(string text, int buttonID)
    {
        GameObject createdButton = Instantiate(buttonPrefab, buttonParent);
        createdButton.GetComponentInChildren<TextMeshProUGUI>().text = text;
        createdButtons.Add(createdButton);

        createdButton.GetComponent<Button>().onClick.AddListener(delegate { Select(buttonID); });
    }

    public void RemoveButtons()
    {
        while (createdButtons.Count >= 1)
        {
            Destroy(createdButtons[0]);
            createdButtons.RemoveAt(0);
        }
    }

    public void Select(int id)
    {
        GetComponent<DialogueManager>().SelectChoice(id);
    }
}
