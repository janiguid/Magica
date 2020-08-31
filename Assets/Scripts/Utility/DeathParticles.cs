using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticles : MonoBehaviour
{
    [SerializeField] private ParticleSystem fireExp;
    [SerializeField] private ParticleSystem waterExp;
    [SerializeField] private ParticleSystem grassExp;

    private Dictionary<Type.ElementalSpellTypes, ParticleSystem> particleDict;
    
    
    // Start is called before the first frame update
    void Start()
    {
        particleDict = new Dictionary<Type.ElementalSpellTypes, ParticleSystem>();
        particleDict.Add(Type.ElementalSpellTypes.Fire, fireExp);
        particleDict.Add(Type.ElementalSpellTypes.Water, waterExp);
        particleDict.Add(Type.ElementalSpellTypes.Grass, grassExp);
    }


    public void Play(Type.ElementalSpellTypes type, Transform trans)
    {
        transform.position = trans.position;
        if (particleDict.ContainsKey(type))
        {
            particleDict[type].Play();
        }
        else
        {
            particleDict[Type.ElementalSpellTypes.Fire].Play();
        }

         
        
    }

    
}
