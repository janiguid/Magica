using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    private Dictionary<Type.ElementalSpellTypes, GameObject> codex;


    [SerializeField] private GameObject SPL_FireBall;
    [SerializeField] private GameObject SPL_IceBall;

    // Start is called before the first frame update
    void Start()
    {
        codex = new Dictionary<Type.ElementalSpellTypes, GameObject>();

        codex.Add(Type.ElementalSpellTypes.Fire, SPL_FireBall);
        codex.Add(Type.ElementalSpellTypes.Water, SPL_IceBall);
    }


    public GameObject GetSpell(Type.ElementalSpellTypes type)
    {
        if (codex.ContainsKey(type) == false) return codex[Type.ElementalSpellTypes.Fire];
        return codex[type];
    }
}
