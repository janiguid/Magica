using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character))]
public class PlayerStats : MonoBehaviour
{
    [Header("Current Player Stats")]
    [SerializeField] private float health;
    [SerializeField] private float defense;
    [SerializeField] private float attack;

    private Character playerChar;
    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<Character>())
        {
            playerChar = GetComponent<Character>();
        }

        health = playerChar.GetHealth();
        defense = playerChar.GetDefense();
        attack = playerChar.GetAttack();
    }

    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;
        }
    }

    public float Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public float Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }
}
