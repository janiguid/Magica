using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterQueue : MonoBehaviour
{
    [SerializeField] private MonsterPool monsterPool;
    [SerializeField] private float timerBeforeNextSpawn;
    [SerializeField] private float timer;
    [SerializeField] private SO_LevelConfig lvlConfig;
    [SerializeField] private int[] orderOfMonsters;
    [SerializeField] private Type.MonsterTypes[] monsterTypes;
    [SerializeField] private int monsterIndexCounter;
    [SerializeField] private GameObject gameOverButton; 
    // Start is called before the first frame update
    void Start()
    {
        timer = timerBeforeNextSpawn;
        monsterPool = FindObjectOfType<MonsterPool>();

        orderOfMonsters = lvlConfig.GetOrdering();
        monsterTypes = lvlConfig.GetMonsterOrder();

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
        
        if (monsterIndexCounter >= monsterTypes.Length)
        {
            if (monsterPool.IsEmpty())
            {
                gameOverButton.SetActive(true);
                return;
            }

        }
        else
        {
            GameObject Fresh = monsterPool.FindFromPool(monsterTypes[monsterIndexCounter]);
            Fresh.transform.position = GetNewPosition();
            Fresh.SetActive(true);
            monsterIndexCounter++;

        }

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
