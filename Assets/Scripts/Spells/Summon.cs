using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summon : Spell
{
    [SerializeField] protected LayerMask layer;

    [SerializeField] protected float duration;
    [SerializeField] protected float speedMod;

    public override void SetTarget(Vector2 tgt, Vector2 playerPosition)
    {
        Vector3 t = tgt;
        target = tgt;

        t.z = Random.Range(-1f, 0f);
        
        transform.position = t;
    }

    public float GetLifeTime()
    {
        return lifeTime;
    }
}
