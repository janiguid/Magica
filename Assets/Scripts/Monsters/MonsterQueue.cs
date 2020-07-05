using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterQueue : MonoBehaviour
{
    [SerializeField] private SO_LevelConfig config;
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
        EnemyQueue = new Queue<GameObject>();

        Produce(config.FireMonsterCount, Type.ElementalType.Fire);
        Produce(config.WaterMonsterCount, Type.ElementalType.Water);
        Produce(config.GrassMonsterCount, Type.ElementalType.Grass);

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
            PopFromQueue();
        }
    }

    void PopFromQueue()
    {
        if (EnemyQueue.Count == 0)
        {
            print("game done");
            return;
        }
        EnemyQueue.Dequeue().SetActive(true);
    }

    void BeginLevel()
    {
        PopFromQueue();
    }

    Vector2 Relocate()
    {
        Vector2 result;
        int randomSpot = Screen.width / 4;

        randomSpot = randomSpot * Random.Range(1, 4);

        result = Camera.main.ScreenToWorldPoint(new Vector2(randomSpot, Screen.height + 100));
        return result;
    }



    void Produce(int enemiesToProduce, Type.ElementalType type)
    {
        for (int i = 0; i < enemiesToProduce; ++i)
        {
            GameObject temp = Instantiate(BaseCopy);
            temp.transform.position = Relocate();
            temp.SetActive(false);
            temp.GetComponent<Monster>().SetElement(type);
            EnemyQueue.Enqueue(temp);
        }
    }


}
