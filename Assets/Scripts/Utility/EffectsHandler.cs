using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsHandler : MonoBehaviour
{
    [SerializeField] private ParticleSystem MyParticles;
    [SerializeField] private AudioSource MyAudio;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayEffects()
    {
        MyParticles.Play();
    }

    public void PlayAudio()
    {
        MyAudio.Play();
    }
}
