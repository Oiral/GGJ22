using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum audioTracks { key, button};

public class AudioManager : MonoBehaviour
{
    public AudioSource keyStroke;
    public AudioSource buttonPress;


    public void PlaySound(audioTracks sound)
    {
        switch (sound)
        {
            case audioTracks.key:
                keyStroke.Play();
                break;
            case audioTracks.button:
                buttonPress.Play();
                break;
            default:
                break;
        }
    }
}
