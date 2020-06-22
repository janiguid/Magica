using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Spell
{


    // Update is called once per frame
    void Update()
    {

    }


    public override void SetElement()
    {
        print("Successfully set to neutral");
        element = Type.ElementalType.Neutral;
    }

    public override bool Trigger(float x, float y)
    {
        if (xMin < x && x < xMax)
        {
            if (yMin < y && y < yMax)
            {
                print(element);

                return true;
            }
        }
        return false;
    }
}
