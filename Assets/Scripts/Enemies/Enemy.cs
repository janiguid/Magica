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
        ModifySpeed(effect.SpeedModifier, effect.SpeedModDuration);
        ModifyAttack(effect.AttackModifier, effect.AttackModDuration);
        ModifyAttack(effect.DefenseModifier, effect.DefenseModDuration);
    }

    public virtual void ModifySpeed(float multiplier, float duration)
    {
        if (multiplier == 0) return;
        speed *= multiplier;
        StartCoroutine(DecreaseSpeedTimer(duration));
    }

    public virtual void ModifyAttack(float multiplier, float duration)
    {
        if (multiplier == 0) return;
        attack *= multiplier;
    }

    public virtual void ModifyDefense(float multiplier, float duration)
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


    IEnumerator DecreaseSpeedTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        speed = iniSpeed;
    }

    IEnumerator DecreaseAttackTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        attack = iniAttack;
    }

    IEnumerator DecreaseDefenseTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        defense = iniDefense;
    }


    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<IDamageable>().ApplyDamage(attack);
            gameObject.SetActive(false);
        }
    }
}
