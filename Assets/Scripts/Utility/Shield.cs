﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shield : MonoBehaviour, IDamageable
{
    [SerializeField]
    private SO_PlayerStats MyStats;

    [SerializeField]
    private float MyHealth;
    // Start is called before the first frame update
    void Start()
    {
        MyHealth = MyStats.ShieldHealth;
    }


    public void ApplyDamage(float dam)
    {
        MyHealth -= dam;

        if (MyHealth <= 0)
        {
            //MonsterPool.AddToInactivePool(gameObject);
            SceneManager.LoadScene(1);
            print("GAME OVER NOOB");
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
