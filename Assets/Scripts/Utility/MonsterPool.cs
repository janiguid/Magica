using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    [SerializeField] private SO_LevelConfig config;
    [SerializeField] private List<GameObject> EnemyPool;
    [SerializeField] private Queue<GameObject> EnemyQueue;
    [SerializeField] private GameObject BaseCopy;
    [SerializeField] private int inactiveSpawn;
    [SerializeField] private int activeSpawn;
    [SerializeField] private float timerBeforeNextSpawn;
    [SerializeField] private float timer;

    

    // Start is called before the first frame update
    void Start()
    {
        timer = timerBeforeNextSpawn;
        EnemyPool = new List<GameObject>();

        Produce(config.FireMonsterCount, Type.ElementalType.Fire);
        Produce(config.WaterMonsterCount, Type.ElementalType.Water);
        Produce(config.GrassMonsterCount, Type.ElementalType.Grass);

        ReactivateEnemy();
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
            timer = timerBeforeNextSpawn;
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


    void Produce(int enemiesToProduce, Type.ElementalType type)
    {
        for (int i = 0; i < enemiesToProduce; ++i)
        {
            GameObject temp = Instantiate(BaseCopy);
            temp.transform.position = Relocate();
            temp.SetActive(false);
            EnemyPool.Add(temp);
        }
    }
}
