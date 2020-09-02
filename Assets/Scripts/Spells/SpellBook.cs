using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    private Dictionary<Type.ElementalSpellTypes, GameObject> codex;


    [SerializeField] private GameObject fireBall;
    // Start is called before the first frame update
    void Start()
    {
        codex = new Dictionary<Type.ElementalSpellTypes, GameObject>();

        codex.Add(Type.ElementalSpellTypes.Fire, fireBall);
    }


    public GameObject GetSpell(Type.ElementalSpellTypes type)
    {
        if (codex.ContainsKey(type) == false) return codex[Type.ElementalSpellTypes.Fire];
        return codex[type];
    }
}
