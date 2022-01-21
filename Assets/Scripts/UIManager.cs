using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI basicText;
    public string currentString;

    [TextArea]
    public string stringToAdd;

    int currentStringToAddID = -1;

    public float timer;
    public float typeSpeed;

    bool noTimer;
    bool longerTimer;
    private void Update()
    {
        if (currentStringToAddID < stringToAdd.Length)
        {
            timer += Time.deltaTime;

            if (timer > typeSpeed)
            {
                timer = 0;
                AddNextChar();
            }
        }
    }

    void AddNextChar()
    {
        currentStringToAddID++;

        char nextChar = stringToAdd[currentStringToAddID];

        switch (nextChar)
        {
            case ' ':
                currentString += nextChar;
                AddNextChar();
                break;
            case '#':
                //Delete
                currentString = currentString.Remove(currentString.Length - 1);
                break;


            case '*':
                //Pause
                timer = -1;
                break;
            case '^':
                timer = -3;
                break;


            case '{':
                noTimer = true;
                break;
            case '}':
                noTimer = false;
                break;


            case '[':
                longerTimer = true;
                break;
            case ']':
                longerTimer = false;
                break;


            default:
                currentString += nextChar;
                break;
        }
        if (longerTimer) timer = -typeSpeed;

        if (noTimer) AddNextChar();
        UpdateVisual();
        
    }
    void UpdateVisual()
    {
        basicText.text = currentString;
    }

    public void NewString(string newString)
    {
        basicText.text = "";
        stringToAdd = newString;
        currentString = "";
        timer = 0;
        currentStringToAddID = -1;
    }
}
