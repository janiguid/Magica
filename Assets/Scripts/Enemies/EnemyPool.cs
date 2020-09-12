using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private List<GameObject> enemyPool;
    [SerializeField] private int initialEnemyCount;
    [SerializeField] private int totalEnemyCount;


    [SerializeField] private float spawnRatePerSecond;
    WaitForSeconds wait;
    // Start is called before the first frame update
    void Start()
    {
        if (initialEnemyCount <= 0) initialEnemyCount = 5;

        if(enemies.Length > 0)
        {
            for (int i = 0; i < initialEnemyCount; ++i)
            {
                
                GameObject temp = Instantiate(enemies[Random.Range(0, enemies.Length)]);
                temp.SetActive(false);
                enemyPool.Add(temp);
            }
        }

        if (spawnRatePerSecond <= 0) spawnRatePerSecond = 2f;

        wait = new WaitForSeconds(spawnRatePerSecond);
        StartCoroutine(Spawner());
    }

    

    IEnumerator Spawner()
    {
        while (true)
        {
            yield return wait;
            SpawnEnemy();
        }

    }



    void SpawnEnemy()
    {

        Vector3 corrected = new Vector3(
        Random.Range(0, Screen.width),
        Random.Range(Screen.height / 2, Screen.height),
        0
        );

        corrected = Camera.main.ScreenToWorldPoint(corrected);
        corrected.z = -1;

        for (int i = 0; i < enemyPool.Count; ++i)
        {
            if(enemyPool[i].gameObject.activeSelf == false)
            {

                enemyPool[i].transform.position = corrected;
                    
                enemyPool[i].SetActive(true);
                return;
            }
        }

        GameObject temp = Instantiate(enemies[0]);
        temp.SetActive(true);
        enemyPool.Add(temp);
        
    }

}
