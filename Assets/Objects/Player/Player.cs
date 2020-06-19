using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spell
{

    // Update is called once per frame
    void Update()
    {

    }

    public override bool Trigger(float x, float y)
    {
        if (xMin < x && x < xMax)
        {
            if (yMin < y && y < yMax)
            {
                print("Player cast!");

                return true;
            }
        }
        return false;
    }
}
