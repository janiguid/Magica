using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell_Fire : Spell
{
    public override bool Trigger(float x, float y)
    {
        if (xMin < x && x < xMax)
        {
            if (yMin < y && y < yMax)
            {
                print("In Fire!");

                return true;
            }
        }

        return false;
    }

}
