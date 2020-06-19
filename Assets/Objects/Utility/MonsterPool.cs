﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{

    public static List<GameObject> EnemyPool;

    public GameObject BaseCopy;


    public float timer = 3;

    // Start is called before the first frame update
    void Start()
    {
        EnemyPool = new List<GameObject>();
        Produce(10, false);

        print(Screen.width);
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 3;
            ReactivateEnemy();
        }
    }

    Vector2 Relocate()
    {
        Vector2 result;
        int randomSpot = Screen.width/4;

        randomSpot = randomSpot * Random.Range(1, 4);
        
        result = Camera.main.ScreenToWorldPoint(new Vector2(randomSpot, Screen.height + 100));
        return result;
    }

    void ReactivateEnemy()
    {
        for(int i = 0; i < EnemyPool.Count; ++i)
        {
            if(EnemyPool[i].activeSelf == false)
            {
                EnemyPool[i].SetActive(true);
                EnemyPool[i].transform.position = Relocate();
                return;
            }
        }

        print("Failed pooling!");
    }


    public static void AddToInactivePool(GameObject enemy)
    {
        EnemyPool.Add(enemy);
    }

    void Produce(int enemiesToProduce, bool active)
    {
        for (int i = 0; i < enemiesToProduce; ++i)
        {
            GameObject temp = Instantiate(BaseCopy);
            temp.transform.position = Relocate();
            temp.SetActive(active);
            EnemyPool.Add(temp);
        }
    }
}
