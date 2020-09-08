using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private Sprite portrait;
    [SerializeField] private float baseHealth;
    [SerializeField] private float baseAttack;
    [SerializeField] private float baseDefense;
    [SerializeField] private float baseSpeed;

    //public Character(Sprite port, float health, float atk, float def)
    //{
    //    baseHealth = health;
    //    portrait = port;
    //    baseAttack = atk;
    //    baseDefense = def;
    //}

    public Sprite GetSprite()
    {
        return portrait;
    }

    public float GetHealth()
    {
        return baseHealth;
    }

    public float GetAttack()
    {
        return baseAttack;
    }

    public float GetDefense()
    {
        return baseDefense;
    }
}
