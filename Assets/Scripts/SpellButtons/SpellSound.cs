using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellSound : MonoBehaviour
{

    [SerializeField] private AudioClip sound;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();

        if(sound != null)
        {
            audioSource.clip = sound;
        }
        
        audioSource.playOnAwake = false;
    }

    public void PlaySound()
    {
        audioSource.Play();
    }
}
