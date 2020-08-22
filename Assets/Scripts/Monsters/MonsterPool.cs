using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    [SerializeField] private SO_LevelConfig config;
    [SerializeField] private List<GameObject> EnemyPool;
    [SerializeField] private GameObject BaseCopy;
    [SerializeField] private Sprite[] SpriteArray;
    [SerializeField] private EffectsHandler MonsterEffects;
    private MonsterSpriteDictionary spriteDictionary;


    private void Awake()
    {
        MonsterEffects = FindObjectOfType<EffectsHandler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        EnemyPool = new List<GameObject>();
        spriteDictionary = new MonsterSpriteDictionary();
    }

    public GameObject FindFromPool(Type.MonsterTypes type)
    {
        for(int i = 0; i < EnemyPool.Count; ++i)
        {
            if (EnemyPool[i].gameObject.activeSelf == true) continue;
            if(EnemyPool[i].GetComponent<Monster>().GetElement() == type)
            {
                print("Extracted from pool");
                return EnemyPool[i];
            }
        }

        print("had to create new monster");
        //if cant find one, grow pool
        return CreateMonster(type);
    }

    void Produce(int enemiesToProduce, Type.MonsterTypes type)
    {
        for (int i = 0; i < enemiesToProduce; ++i)
        {
            CreateMonster(type);
        }
    }

    GameObject CreateMonster(Type.MonsterTypes type)
    {
        GameObject temp = Instantiate(BaseCopy);
        temp.SetActive(false);

        if (temp == null) print("Missing temp");
        temp.GetComponent<Monster>().ConfigureMonster(type, spriteDictionary.GetMonsterSprite(type), ref MonsterEffects);
        EnemyPool.Add(temp);
        return temp;
    }

    public bool IsEmpty()
    {
        for(int i = 0; i < EnemyPool.Count; ++i)
        {
            if(EnemyPool[i].activeSelf == true)
            {
                return false;
            }
        }

        return true;
    }
}


//[SerializeField] private SO_LevelConfig config;
//[SerializeField] private List<GameObject> EnemyPool;
//[SerializeField] private Queue<GameObject> EnemyQueue;
//[SerializeField] private GameObject BaseCopy;
//[SerializeField] private int inactiveSpawn;
//[SerializeField] private int activeSpawn;
//[SerializeField] private float timerBeforeNextSpawn;
//[SerializeField] private float timer;



//// Start is called before the first frame update
//void Start()
//{
//    timer = timerBeforeNextSpawn;
//    EnemyPool = new List<GameObject>();

//    Produce(config.FireMonsterCount, Type.ElementalType.Fire);
//    Produce(config.WaterMonsterCount, Type.ElementalType.Water);
//    Produce(config.GrassMonsterCount, Type.ElementalType.Grass);

//    ReactivateEnemy();
//}

//// Update is called once per frame
//void Update()
//{
//    if (timer > 0)
//    {
//        timer -= Time.deltaTime;
//    }
//    else
//    {
//        timer = timerBeforeNextSpawn;
//        ReactivateEnemy();
//    }
//}

//Vector2 Relocate()
//{
//    Vector2 result;
//    int randomSpot = Screen.width / 4;

//    randomSpot = randomSpot * Random.Range(1, 4);

//    result = Camera.main.ScreenToWorldPoint(new Vector2(randomSpot, Screen.height + 100));
//    return result;
//}

//void ReactivateEnemy()
//{
//    for (int i = 0; i < EnemyPool.Count; ++i)
//    {
//        if (EnemyPool[i].activeSelf == false)
//        {
//            EnemyPool[i].SetActive(true);
//            EnemyPool[i].transform.position = Relocate();
//            return;
//        }
//    }

//    print("Failed pooling!");
//}


//void Produce(int enemiesToProduce, Type.ElementalType type)
//{
//    for (int i = 0; i < enemiesToProduce; ++i)
//    {
//        GameObject temp = Instantiate(BaseCopy);
//        temp.transform.position = Relocate();
//        temp.SetActive(false);
//        EnemyPool.Add(temp);
//    }
//}