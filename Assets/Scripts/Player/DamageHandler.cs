using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHandler : MonoBehaviour, IDamageable
{
    [Header("Player Stats")]
    [SerializeField] private float health;
    [SerializeField] private float defense;
    [SerializeField] private float attack;

    public void ApplyDamage(float dam)
    {
        health -= dam - defense / 2;

        if (health <= 0) print("I am dead");
    }



}
