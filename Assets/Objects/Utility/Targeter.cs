using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{

    public GameObject ClosestMonster;
    public Monster[] Monsters;
    public Vector2 ClosestPos;
    public Vector2 MaxPos;


    private void Start()
    {
        MaxPos = GameObject.FindObjectOfType<Shield>().transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //maybe I can do this check every time a monster is spawned?
        //this implies monsters will have constant speeds though

        Monsters = GameObject.FindObjectsOfType<Monster>();


        for(int i = 0; i < Monsters.Length; ++i)
        {
            if (Monsters[i].gameObject.transform.position.y > ClosestMonster.transform.position.y)
            {
                Monsters[i].GetComponent<SpriteRenderer>().color = Color.red;
            }

            if (Monsters[i].gameObject.transform.position.y <= ClosestMonster.transform.position.y)
            {
                ClosestMonster = Monsters[i].gameObject;
                ClosestMonster.GetComponent<SpriteRenderer>().color = Color.yellow;
                ClosestPos = ClosestMonster.transform.position;
            }
            else
            {
                ClosestMonster = Monsters[i].gameObject;
                //Monsters[i].gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }

        }
        
    }

    public GameObject GetClosestMonster()
    {

        return ClosestMonster;
    }
}
