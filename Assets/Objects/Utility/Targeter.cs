using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeter : MonoBehaviour
{

    public GameObject ClosestMonster;
    Monster[] Monsters;

    // Update is called once per frame
    void Update()
    {
        //maybe I can do this check every time a monster is spawned?
        //this implies monsters will have constant speeds though

        Monsters = GameObject.FindObjectsOfType<Monster>();

        for(int i = 0; i < Monsters.Length; ++i)
        {
            if(Monsters[i].gameObject.transform.position.y > ClosestMonster.transform.position.y)
            {
                print("found new monster");
                ClosestMonster = Monsters[i].gameObject;
            }
        }
        
    }

    public GameObject GetClosestMonster()
    {

        return ClosestMonster;
    }
}
