using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Character), typeof(PlayerStats))]
public class DamageHandler : MonoBehaviour, IDamageable
{

    private Character playerChar;
    private PlayerStats playerStats;

    private void Start()
    {
        if (GetComponent<Character>())
        {
            playerChar = GetComponent<Character>();
        }

        if (GetComponent<PlayerStats>())
        {
            playerStats = GetComponent<PlayerStats>();
        }
    }

    public void ApplyDamage(float dam)
    {
        if (playerChar)
        {
            float updatedHealth = playerStats.Health - (dam - (playerStats.Defense * .1f));
            playerStats.Health = updatedHealth;

            if (playerStats.Health <= 0) print("I am dead");
        }

    }



}
