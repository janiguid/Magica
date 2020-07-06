﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterQueue : MonoBehaviour
{
    [SerializeField] private MonsterPool monsterPool;
    [SerializeField] private float timerBeforeNextSpawn;
    [SerializeField] private float timer;
    [SerializeField] private SO_LevelConfig lvlConfig;
    [SerializeField] private int[] orderOfMonsters;
    [SerializeField] private int monsterIndexCounter;

    // Start is called before the first frame update
    void Start()
    {
        timer = timerBeforeNextSpawn;
        monsterPool = FindObjectOfType<MonsterPool>();

        orderOfMonsters = lvlConfig.GetOrdering();

        BeginLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = timerBeforeNextSpawn;
            SpawnMonster();
        }
    }

    void SpawnMonster()
    {
        monsterIndexCounter++;
        if (monsterIndexCounter >= orderOfMonsters.Length)
        {
            print("game done");

            return;
        }

        GameObject Fresh = monsterPool.FindFromPool((Type.ElementalType)orderOfMonsters[monsterIndexCounter]);
        Fresh.transform.position = GetNewPosition();
        Fresh.SetActive(true);
    }

    void BeginLevel()
    {
        SpawnMonster();
    }

    Vector2 GetNewPosition()
    {
        Vector2 result;
        int randomSpot = Screen.width / 4;

        randomSpot = randomSpot * Random.Range(1, 4);

        result = Camera.main.ScreenToWorldPoint(new Vector2(randomSpot, Screen.height + 100));
        return result;
    }

}
