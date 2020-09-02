using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Spell
{
    [Header("Damage Values")]
    [SerializeField] protected float damageValue;
    

    [Header("Stat Modifiers")]
    [SerializeField] protected float speedDebuff;
    [SerializeField] protected float attackDebuff;
    [SerializeField] protected float defenseDebuff;


    public override void SetTarget(Vector2 tgt)
    {
        target = tgt;
    }
}
