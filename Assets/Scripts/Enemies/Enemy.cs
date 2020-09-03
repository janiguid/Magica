using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable, IModifiable
{
    [Header("Monster Stats")]
    [SerializeField] protected float health;
    [SerializeField] protected float attack;
    [SerializeField] protected float speed;
    [SerializeField] protected float defense;

    protected float iniHealth;
    protected float iniAttack;
    protected float iniSpeed;
    protected float iniDefense;

    protected Vector2 playerLocation;

    private void Start()
    {
        iniHealth = health;
        iniAttack = attack;
        iniSpeed = speed;
        iniDefense = defense;

        playerLocation = FindObjectOfType<Player>().transform.position;
    }
    public virtual void ApplyDamage(float dam)
    {
    }

    public virtual void ModifyStats(SpellEffect effect)
    {
        ModifySpeed(effect.SpeedModifier);
        ModifyAttack(effect.AttackModifier);
        ModifyAttack(effect.DefenseModifier);
    }

    public virtual void ModifySpeed(float multiplier)
    {
        if (multiplier == 0) return;
        speed *= multiplier;
    }

    public virtual void ModifyAttack(float multiplier)
    {
        if (multiplier == 0) return;
        attack *= multiplier;
    }

    public virtual void ModifyDefense(float multiplier)
    {
        if (multiplier == 0) return;
        defense *= multiplier;
    }

    public virtual void ClearDebuffs()
    {
        health = iniHealth;
        attack = iniAttack;
        speed = iniSpeed;
        defense = iniDefense;
    }
}
