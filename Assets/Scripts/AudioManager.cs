using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum audioTracks { key};

public class AudioManager : MonoBehaviour
{
    public AudioSource keyStroke;


    public void PlaySound(audioTracks sound)
    {
        switch (sound)
        {
            case audioTracks.key:
                keyStroke.Play();
                break;
            default:
                break;
        }
    }
}
