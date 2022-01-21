using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI basicText;
    public string currentString;

    public string stringToAdd;

    int currentStringToAddID = -1;

    public float timer;
    public float typeSpeed;
    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > (currentStringToAddID * typeSpeed))
        {
            AddNextChar();
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
                currentString = currentString.Remove(currentString.Length - 1);
                break;
            case '^':
                break;
            default:
                currentString += nextChar;
                break;
        }

        
        

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
        timer = 0;
        currentStringToAddID = -1;
    }
}
