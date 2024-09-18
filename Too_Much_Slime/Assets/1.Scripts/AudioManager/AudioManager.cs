using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
    public AudioSource audioSource;
    public AudioClip[] audioClip;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
