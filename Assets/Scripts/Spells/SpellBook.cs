using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBook : MonoBehaviour
{
    private Dictionary<Type.ElementalSpellTypes, GameObject> codex;

    [Header("Projectiles")]
    [SerializeField] private GameObject SPL_FireBall;
    [SerializeField] private GameObject SPL_IceBall;

    [Header("Summons")]
    [SerializeField] private GameObject SUM_FrozenPuddle;

    // Start is called before the first frame update
    void Start()
    {
        codex = new Dictionary<Type.ElementalSpellTypes, GameObject>();


        //projectiles
        codex.Add(Type.ElementalSpellTypes.Fire, SPL_FireBall);
        codex.Add(Type.ElementalSpellTypes.Water, SPL_IceBall);


        //summons
        codex.Add(Type.ElementalSpellTypes.Grass, SUM_FrozenPuddle);
    }


    public GameObject GetSpell(Type.ElementalSpellTypes type)
    {
        if (codex.ContainsKey(type) == false) return codex[Type.ElementalSpellTypes.Fire];
        return codex[type];
    }
}
