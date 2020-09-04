using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Spell
{
    [Header("Damage Values")]
    [SerializeField] protected float damageValue;
    [SerializeField] protected float projectileSpeed;

    [Header("Stat Modifiers")]
    [SerializeField] protected float speedDebuff;
    [SerializeField] protected float attackDebuff;
    [SerializeField] protected float defenseDebuff;

    [Header("Stat Mod Timers")]
    [SerializeField] protected float spdModDuration;
    [SerializeField] protected float atkModDuration;
    [SerializeField] protected float defModDuration;
    private Rigidbody2D rb2D;


    public override void SetTarget(Vector2 tgt, Vector2 playerPosition)
    {
        rb2D = GetComponent<Rigidbody2D>();
        target = tgt;

        Vector2 temp = tgt;

        temp = temp - playerPosition;

        if (projectileSpeed == 0) projectileSpeed = 5;
        rb2D.velocity = temp.normalized * projectileSpeed;
    }
}
