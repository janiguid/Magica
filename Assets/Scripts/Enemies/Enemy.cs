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

    protected Vector2 playerLocation;

    private void Start()
    {
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
        speed *= multiplier;
    }

    public virtual void ModifyAttack(float multiplier)
    {
        attack *= multiplier;
    }

    public virtual void ModifyDefense(float multiplier)
    {
        defense *= multiplier;
    }
}
