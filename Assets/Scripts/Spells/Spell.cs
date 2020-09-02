using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    [Header("Modifiers")]
    [SerializeField] private float speedMod;


    [SerializeField] protected Vector2 target;
    [SerializeField] protected float lifeTime;
    protected SpellEffect spellEffect;


    private void Start()
    {
        target = Vector2.zero;
    }
    public virtual void SetTarget(Vector2 tgt) { }

}
