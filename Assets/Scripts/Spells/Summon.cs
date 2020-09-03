using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : Spell
{
    [SerializeField] protected float duration;
    [SerializeField] protected float speedMod;

    public override void SetTarget(Vector2 tgt, Vector2 playerPosition)
    {
        target = tgt;
        transform.position = target;
    }
}
