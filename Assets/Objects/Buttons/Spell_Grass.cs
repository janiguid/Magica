using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Grass : Spell
{
    public override bool Trigger(float x, float y)
    {
        if(xMin < x && x < xMax)
        {
            if(yMin < y && y < yMax)
            {
                print("In Grass!");
                return true;
            }
        }

        return false;   
    }

}
