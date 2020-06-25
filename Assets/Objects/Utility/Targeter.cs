using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{

    public GameObject ClosestMonster;
    public Monster[] Monsters;
    public Vector2 MinPos;
    public Vector2 MaxPos;
    public Vector2 InitialMin;

    private void Start()
    {
        MaxPos = GameObject.FindObjectOfType<Shield>().transform.position;
        MaxPos.y += 0.1f;
        InitialMin = GameObject.FindObjectOfType<MonsterPool>().transform.position;
        MinPos = InitialMin;
    }

    // Update is called once per frame
    void Update()
    {
        //maybe I can do this check every time a monster is spawned?
        //this implies monsters will have constant speeds though

        Monsters = GameObject.FindObjectsOfType<Monster>();


        for(int i = 0; i < Monsters.Length; ++i)
        {
            if (MinPos.y <= MaxPos.y) MinPos = InitialMin;

            if(Monsters[i].transform.position.y < MinPos.y)
            {
                ClosestMonster = Monsters[i].gameObject;
                MinPos.y = ClosestMonster.transform.position.y;
                ClosestMonster.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else
            {
                Monsters[i].GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
        
    }

    public GameObject GetClosestMonster()
    {
        return ClosestMonster;
    }
}
