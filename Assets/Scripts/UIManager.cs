using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI basicText;
    public string currentString;

    [TextArea]
    public string stringToAdd;

    public AudioManager audioManager;

    int currentStringToAddID = -1;

    public float timer;
    public float typeSpeed;

    bool noTimer;
    bool longerTimer;
    bool colouring;
    string endingTag;


    public UnityEvent onStart;
    public UnityEvent onFinish;
    
    private void Update()
    {
        if (currentStringToAddID < stringToAdd.Length -1)
        {
            timer += Time.deltaTime;

            if (timer > typeSpeed)
            {
                timer = 0;
                AddNextChar();
            }
            
            if (currentStringToAddID == stringToAdd.Length-1)
            {
                Debug.Log("Finished");
                onFinish.Invoke();
            }
        }
    }

    void AddNextChar()
    {
        currentStringToAddID++;

        if (currentStringToAddID >= stringToAdd.Length)
        {
            return;
        }

        string nextChar = stringToAdd[currentStringToAddID].ToString();

        switch (nextChar)
        {
            case " ":
                AddChar(nextChar);
                AddNextChar();
                break;
            case "$":
                //Delete
                if (currentString.Length >= 1)
                {
                    currentString = currentString.Remove(currentString.Length - 1);
                    audioManager.PlaySound(audioTracks.key);
                }
                else
                {
                    AddNextChar();
                }
                break;


            case "*":

                //Pause
                timer = -1;
                break;
            case "^":
                timer = -3;
                break;


            case "{":
                noTimer = true;
                break;
            case "}":
                noTimer = false;
                break;


            case "[":
                longerTimer = true;
                break;
            case "]":
                longerTimer = false;
                break;

            case "<":
                noTimer = true;
                colouring = false;
                AddChar(nextChar);

                switch (stringToAdd[currentStringToAddID + 1])
                {
                    case 'c':
                        endingTag = "color";
                        break;
                    case 'b':
                        endingTag = "b";
                        break;
                }

                break;
            case ">":
                noTimer = false;
                
                if (!colouring)
                {
                    AddChar(nextChar);
                    //Add in the </color> at the end
                    AddChar("</" + endingTag + ">");
                    colouring = true;
                }
                else
                {
                    colouring = false;
                }

                
                break;

            default:
                audioManager.PlaySound(audioTracks.key);
                AddChar(nextChar);
                break;
        }
        if (longerTimer) timer = -typeSpeed;

        if (noTimer) AddNextChar();
        UpdateVisual();
        
    }

    void AddChar(string charToAdd)
    {
        if (colouring)
        {
            currentString = currentString.Insert(currentString.Length - (endingTag.Length + 3), charToAdd);
        }
        else
        {
            currentString += charToAdd;
        }
        
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

        noTimer = false;
        longerTimer = false;
        colouring = false;

        onStart.Invoke();
    }
}